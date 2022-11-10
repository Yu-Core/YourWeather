using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Weather.WeatherResult;

namespace YourWeather.Model.Weather.WeatherSource
{
    public class AmapSource : IWeatherSource
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }

        public async Task<WeatherData> WeatherData(double lat, double lon)
        {
            using HttpClient Http = new HttpClient();

            var city = await GetCityAsync(lat, lon);
            if (string.IsNullOrEmpty(city))
            {
                return null;
            }

            WeatherLives? live = await Lives(Http, city);
            List<WeatherForecastDay>? forecastDay = await ForecastDay(Http, city);

            WeatherData weatherData = new WeatherData()
            {
                Lives = live,
                ForecastDays = forecastDay
            };
            return weatherData;
        }

        public async Task<WeatherLives?> Lives(HttpClient Http,string city)
        {
            
            //获取天气实况
            var livesUrl = $"https://restapi.amap.com/v3/weather/weatherInfo?city={city}&key={Key}";
            AmapResultLives? lives = null;
            try
            {
                lives = await Http.GetFromJsonAsync<AmapResultLives>(livesUrl);
            }
            catch (Exception)
            {

                throw;
            }

            if (lives is null)
                return null;

            bool state = Convert.ToInt16(lives.Status) == 0 || Convert.ToInt32(lives.Infocode) != 10000;
            if (state)
                return null;

            if (lives.Lives is null)
                return null;

            WeatherLives weatherLives = new WeatherLives()
            {
                City = lives.Lives[0].City,
                Weather = lives.Lives[0].Weather,
                Temp = lives.Lives[0].Temperature,
                WindDeg = lives.Lives[0].Winddirection + "风",
                WindScale = (lives.Lives[0].Windpower??string.Empty).Replace("≤","") ,
                Humidity = lives.Lives[0].Humidity,
            };
            return weatherLives;

        }


        public async Task<List<WeatherForecastDay>?> ForecastDay(HttpClient Http, string city)
        {
            var forecastUrl = $"https://restapi.amap.com/v3/weather/weatherInfo?city={city}&key={Key}&extensions=all";
            AmapResultForecastDay? forecast = null;
            try
            {
                forecast = await Http.GetFromJsonAsync<AmapResultForecastDay>(forecastUrl);
            }
            catch (Exception)
            {

                throw;
            }

            if (forecast is null)
                return null;

            bool state = Convert.ToInt16(forecast.Status) == 0 || Convert.ToInt32(forecast.Infocode) != 10000;
            if (state)
                return null;

            List<WeatherForecastDay> forecastDays = new();
            foreach (var item in forecast.Forecasts[0].Casts)
            {
                WeatherForecastDay forecastDay = new()
                {
                    Weather = item.Dayweather,
                    Date = DateTime.ParseExact(item.Date, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture),
                    MaxTemp = item.Daytemp,
                    MinTemp = item.Nighttemp
                };
                forecastDays.Add(forecastDay);
            }

            return forecastDays;

        }



        private async Task<string?> GetCityAsync(double lat, double lon)
        {

            using HttpClient Http = new HttpClient();
            //获取城市编码
            var locationUrl = $"https://restapi.amap.com/v3/geocode/regeo?location={lon},{lat}&key={Key}";
            AmapResultAdcode? adcode = null;
            try
            {
                adcode = await Http.GetFromJsonAsync<AmapResultAdcode>(locationUrl);
            }
            catch (Exception)
            {

                throw;
            }

            if (adcode is null)
                return null;

            bool state = Convert.ToInt16(adcode.status) == 0 || Convert.ToInt32(adcode.infocode) != 10000;
            if (state)
                return null;

            return adcode.regeocode.addressComponent.adcode;


        }

    }
}
