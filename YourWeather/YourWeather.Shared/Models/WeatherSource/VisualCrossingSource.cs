using System.Net.Http.Json;

namespace YourWeather.Shared
{
    public class VisualCrossingSource : BaseWeatherSource
    {
        public override async Task<WeatherData> GetWeatherData(Location location)
        {
            var lat = location.Lat;
            var lon = location.Lon;
            using HttpClient Http = new();
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
            WeatherLives lives = new()
            {
                Weather = result?.currentConditions?.conditions?.ToWeather(),
                Temp = Convert.ToInt32(result?.currentConditions?.temp).ToString(),
                FeelsLike = Convert.ToInt32(result?.currentConditions?.feelslike).ToString(),
                Humidity = Convert.ToInt32(result?.currentConditions?.humidity).ToString(),
                WindSpeed = Convert.ToInt32(result?.currentConditions?.windspeed).ToString(),
                WindDeg = Convert.ToInt32(result?.currentConditions?.winddir).ToWindDir(),
                Pressure = Convert.ToInt32(result?.currentConditions?.pressure).ToString(),
                Visibility = Convert.ToInt32(result?.currentConditions?.visibility).ToString(),
                Cloud = Convert.ToInt32(result?.currentConditions?.cloudcover).ToString()
            };
            List<WeatherForecastDay> forecastDays = new();
            foreach (var item in result?.days ??default!)
            {
                WeatherForecastDay forecastDay = new()
                {
                    Weather = item?.conditions?.ToWeather(),
                    MaxTemp = Convert.ToInt32(item?.tempmax).ToString(),
                    MinTemp = Convert.ToInt32(item?.tempmin).ToString(),
                    Date = (item??default!).datetimeEpoch.ToDateTime(),
                };
                forecastDays.Add(forecastDay);
            }
            List<WeatherForecastHours> forecastHours = new();
            List<VisualCrossingHour> visualCrossingHours = new();
            bool conform = false;
            bool quit = false;
            foreach (var day in result?.days??default!)
            {
                foreach (var hour in day.hours ?? default!)
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
                WeatherForecastHours forecastHour = new()
                {
                    Weather = item.conditions.ToWeather(),
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
