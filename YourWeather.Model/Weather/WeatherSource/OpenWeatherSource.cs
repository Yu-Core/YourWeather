using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Extend;
using YourWeather.Model.Weather.WeatherResult;

namespace YourWeather.Model.Weather.WeatherSource
{
    public class OpenWeatherSource : BaseWeatherSource
    {
        protected override async Task<WeatherData> ReceiveWeatherData(double lat, double lon)
        {
            WeatherLives? lives = await Lives(lat, lon);
            WeatherData data = new WeatherData()
            {
                Lives = lives
            };
            return data; 
        }

        public async Task<WeatherLives?> Lives(double lat, double lon)
        {
            using HttpClient Http = new HttpClient();
            //获取天气实况
            var livesUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid={Key}&lang=zh_cn";
            OpenWeatherResultLives? lives = null;
            try
            {
                lives = await Http.GetFromJsonAsync<OpenWeatherResultLives>(livesUrl);
            }
            catch (Exception)
            {

                throw;
            }


            if (lives is null)
                return null;

            bool state = lives.cod != 200;
            if (state)
                return null;

            WeatherLives weatherLives = new WeatherLives()
            {
                City = lives.name,
                Weather = lives.weather[0].description,
                Temp = Convert.ToInt32( lives.main.temp).ToString(),
                WindDeg = lives.wind.deg.ToWindDir(),
                WindSpeed = lives.wind.speed.ToString(),
                Humidity = lives.main.humidity.ToString(),
                FeelsLike = Convert.ToInt32(lives.main.feels_like).ToString(),
                Pressure = lives.main.pressure.ToString(),
                Visibility = (Convert.ToInt32(lives.visibility)/1000).ToString(),
                MaxTemp = Convert.ToInt32(lives.main.temp_max).ToString(),
                MinTemp = Convert.ToInt32(lives.main.temp_min).ToString(),
                Cloud = lives.clouds.all.ToString(),
            };
            return weatherLives;
        }


    }
}
