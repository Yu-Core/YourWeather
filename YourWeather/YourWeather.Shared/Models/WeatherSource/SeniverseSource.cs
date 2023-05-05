using System.Net.Http.Json;

namespace YourWeather.Shared
{
    public class SeniverseSource : BaseWeatherSource
    {
        public override async Task<WeatherData> GetWeatherData(Location location)
        {
            var lat = location.Lat;
            var lon = location.Lon;
            using HttpClient Http = new();
            WeatherLives? lives = await Lives(lat, lon,Http);
            List<WeatherForecastDay>? forecastDays = await ForecastDay(lat, lon, Http);
            WeatherData data = new()
            {
                Lives = lives,
                ForecastDays = forecastDays
            };
            return data;
        }

        public async Task<List<WeatherForecastDay>?> ForecastDay(double lat, double lon,HttpClient Http)
        {
            var forecastUrl = $"https://api.seniverse.com/v3/weather/daily.json?key={Key}&location={lat}:{lon}";
            SeniverseResultForeastDay? forecast = null;
            try
            {
                forecast = await Http.GetFromJsonAsync<SeniverseResultForeastDay>(forecastUrl);
            }
            catch (Exception)
            {

                throw;
            }

            if(forecast is null)
                return null;

            List<WeatherForecastDay> forecastDays = new();
            foreach (var item in forecast.results[0].daily)
            {
                WeatherForecastDay forecastDay = new()
                {
                    Weather = item.text_day,
                    Date = DateTime.ParseExact(item.date, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture),
                    MaxTemp = item.high,
                    MinTemp = item.low,
                };
                forecastDays.Add(forecastDay);
            }

            return forecastDays;
        }


        public async Task<WeatherLives?> Lives(double lat, double lon, HttpClient Http)
        {   
            //获取天气实况
            var livesUrl = $"https://api.seniverse.com/v3/weather/now.json?key={Key}&location={lat}:{lon}";
            SeniverseResultLives? lives = null;
            try
            {
                lives = await Http.GetFromJsonAsync<SeniverseResultLives>(livesUrl);
            }
            catch (Exception)
            {

                throw;
            }


            if (lives is null)
                return null;

            WeatherLives weatherLives = new()
            {
                City = lives?.results?[0].location?.name,
                Weather = lives?.results?[0].now?.text,
                Temp = lives?.results?[0].now?.temperature,
            };
            return weatherLives;
        }

        
    }
}
