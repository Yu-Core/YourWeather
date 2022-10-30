using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather.WeatherSource
{
    public class AmapSource : IWeatherSource
    {
        private HttpClient? Http { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }

        public async Task<WeatherLives?> Lives(double lat, double lon)
        {
            
            var city = await GetCityAsync(lat, lon);
            if(string.IsNullOrEmpty(city))
            {
                return null;
            }
            //获取天气实况
            var livesUrl = $"https://restapi.amap.com/v3/weather/weatherInfo?city={city}&key={Key}";
            var livesJson = await Http.GetStringAsync(livesUrl);

            if (string.IsNullOrEmpty(livesJson))
                return null;

            JObject jLives = (JObject)JsonConvert.DeserializeObject(livesJson);

            if (StateError(jLives))
                return null;

            WeatherLives weatherLives = new WeatherLives()
            {
                Weather = jLives["lives"]["weather"].ToString(),
                Temp = jLives["lives"]["temperature"].ToString(),
                WindDeg = jLives["lives"]["winddirection"].ToString(),
                WindSpeed = jLives["lives"]["windpower"].ToString(),
                Humidity = jLives["lives"]["humidity"].ToString()
            };
            return weatherLives;

        }

        public Task<List<WeatherForecastHours>?> ForecastHours(double lat, double lon)
        {
            return null;
        }

        public async Task<List<WeatherForecastDay>?> ForecastDay(double lat, double lon)
        {
            var city = await GetCityAsync(lat, lon);
            if (string.IsNullOrEmpty(city))
            {
                return null;
            }
            var forecastUrl = $"https://restapi.amap.com/v3/weather/weatherInfo?city={city}&key={Key}&extensions=all";
            var forecastJson = await Http.GetStringAsync(forecastUrl);

            if (string.IsNullOrEmpty(forecastJson))
                return null;

            JObject jForecast = (JObject)JsonConvert.DeserializeObject(forecastJson);

            if (StateError(jForecast))
                return null;

            List<WeatherForecastDay> forecastDays = new();

            foreach (var item in jForecast["forecast"]["casts"])
            {
                WeatherForecastDay forecastDay = new()
                {
                    Week = item["week"].ToString(),
                    MaxTemp = item["daytemp"].ToString(),
                    MinTemp = item["nighttemp"].ToString()
                };
                forecastDays.Add(forecastDay);
            }
            return forecastDays;

        }

        private bool StateError(JObject jobj)
        {
            return Convert.ToInt16(jobj["status"]) == 0 || Convert.ToInt32(jobj["infocode"]) != 10000;
        }

        private async Task<string> GetCityAsync(double lat, double lon)
        {
            //获取城市编码
            var locationUrl = $"https://restapi.amap.com/v3/geocode/regeo?location={lat},{lon}&key={Key}";
            var locationJson = await Http.GetStringAsync(locationUrl);

            if (string.IsNullOrEmpty(locationJson))
                return string.Empty;

            JObject jLocation = (JObject)JsonConvert.DeserializeObject(locationJson);

            if (StateError(jLocation))
                return string.Empty;

            return jLocation["regeocode"]["addressComponent"]["adcode"].ToString();
        }
    }
}
