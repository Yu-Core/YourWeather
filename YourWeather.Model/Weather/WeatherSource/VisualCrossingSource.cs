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
    public class VisualCrossingSource : IWeatherSource
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }

        public async Task<WeatherData> WeatherData(double lat, double lon)
        {
            using HttpClient Http = new HttpClient();
            string url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{lat},{lon}?unitGroup=metric&include=hours%2Cdays%2Ccurrent&key={Key}&contentType=json&lang=zh";
            VisualCrossingResult? result = null;
            try
            {
                result = await Http.GetFromJsonAsync<VisualCrossingResult>(url);
            }
            catch (Exception)
            {

                throw;
            }

            if (result == null)
                return null;
            WeatherLives lives = new WeatherLives()
            {
                Weather = result.currentConditions.conditions,
                Temp = Convert.ToInt32(result.currentConditions.temp).ToString(),
                FeelsLike = Convert.ToInt32(result.currentConditions.feelslike).ToString(),
                Humidity = Convert.ToInt32(result.currentConditions.humidity).ToString(),
                WindSpeed = Convert.ToInt32(result.currentConditions.windspeed).ToString(),
                WindDeg = Convert.ToInt32(result.currentConditions.winddir).ToWindDir(),
                Pressure = Convert.ToInt32(result.currentConditions.pressure).ToString(),
                Visibility = Convert.ToInt32(result.currentConditions.visibility).ToString(),
                Cloud = Convert.ToInt32(result.currentConditions.cloudcover).ToString()
            };
            List<WeatherForecastDay> forecastDays = new();
            foreach (var item in result.days)
            {
                WeatherForecastDay forecastDay = new WeatherForecastDay()
                {
                    Weather = item.conditions,
                    MaxTemp = Convert.ToInt32(item.tempmax).ToString(),
                    MinTemp = Convert.ToInt32(item.tempmin).ToString(),
                    Date = item.datetimeEpoch.ToDateTime(),
                };
                forecastDays.Add(forecastDay);
            }
            List<WeatherForecastHours> forecastHours = new();
            List<VisualCrossingHour> visualCrossingHours = new();
            bool conform = false;
            bool quit = false;
            foreach (var day in result.days)
            {
                foreach (var hour in day.hours)
                {
                    if (DateTime.Now.ToString("HH:00:00") == hour.datetime)
                    {
                        if(conform)
                        {
                            quit = true;
                            break;
                        }
                        else
                        {
                            conform = true;
                        }
                    }
                    if (conform)
                    {
                        visualCrossingHours.Add(hour);
                    }
                }
                if(quit)
                {
                    break;
                }
            }
            foreach (var item in visualCrossingHours)
            {
                WeatherForecastHours forecastHour = new WeatherForecastHours()
                {
                    Weather = item.conditions,
                    Temp = Convert.ToInt32(item.temp).ToString(),
                    DateTime = item.datetimeEpoch.ToDateTime(),
                };
                forecastHours.Add(forecastHour);
            }
            WeatherData weatherData = new()
            {
                Lives = lives,
                ForecastDays = forecastDays,
                ForecastHours = forecastHours
            };
            return weatherData;
        }
    }
}
