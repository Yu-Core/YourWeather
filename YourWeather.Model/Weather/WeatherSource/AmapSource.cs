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

        public async Task<WeatherLives?> Lives(double lat, double lon)
        {
            try
            {
                using HttpClient Http = new HttpClient();

                var city = await GetCityAsync(lat, lon);
                if (string.IsNullOrEmpty(city))
                {
                    return null;
                }
                //获取天气实况
                var livesUrl = $"https://restapi.amap.com/v3/weather/weatherInfo?city={city}&key={Key}";
                AmapResultLives lives = new();
                var response = await Http.GetAsync(livesUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lives = JsonConvert.DeserializeObject<AmapResultLives>(content);
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
                    Weather = lives.Lives[0].Weather,
                    Temp = lives.Lives[0].Temperature,
                    WindDeg = lives.Lives[0].Winddirection,
                    WindSpeed = lives.Lives[0].Windpower,
                    Humidity = lives.Lives[0].Humidity
                };
                return weatherLives;
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Get WeatherSource Error");
            }
            
        }

        public Task<List<WeatherForecastHours>?> ForecastHours(double lat, double lon)
        {
            return null;
        }

        public async Task<List<WeatherForecastDay>?> ForecastDay(double lat, double lon)
        {
            try
            {
                using HttpClient Http = new HttpClient();
                var city = await GetCityAsync(lat, lon);
                if (string.IsNullOrEmpty(city))
                {
                    return null;
                }

                var forecastUrl = $"https://restapi.amap.com/v3/weather/weatherInfo?city={city}&key={Key}&extensions=all";
                AmapResultForecast forecast = new();
                var response = await Http.GetAsync(forecastUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    forecast = JsonConvert.DeserializeObject<AmapResultForecast>(content);
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
                        Week = item.Week,
                        MaxTemp = item.Daytemp,
                        MinTemp = item.Nighttemp
                    };
                    forecastDays.Add(forecastDay);
                }

                return forecastDays;
            }
            catch (Exception)
            {
                throw new Exception("Get WeatherSource Error");
            }
            
        }



        private async Task<string?> GetCityAsync(double lat, double lon)
        {
            try
            {
                using HttpClient Http = new HttpClient();
                //获取城市编码
                var locationUrl = $"https://restapi.amap.com/v3/geocode/regeo?location={lat},{lon}&key={Key}";
                AmapResultAdcode adcode = new();
                var response = await Http.GetAsync(locationUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    adcode = JsonConvert.DeserializeObject<AmapResultAdcode>(content);
                }
                
                if (adcode is null)
                    return null;

                bool state = Convert.ToInt16(adcode.status) == 0 || Convert.ToInt32(adcode.infocode) != 10000;
                if (state)
                    return null;

                return adcode.regeocode.addressComponent.adcode;
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Get WeatherSource Error");
            }

        }
    }
}
