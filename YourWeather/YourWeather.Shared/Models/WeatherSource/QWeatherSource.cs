using System.Net;
using System.Net.Http.Json;

namespace YourWeather.Shared
{
    public class QWeatherSource : BaseWeatherSource
    {
        public override async Task<WeatherData> GetWeatherData(Location location)
        {
            var lat = location.Lat;
            var lon = location.Lon;
            //和风天气采用了gzip压缩了数据，需设置HttpClientHandler的AutomaticDecompression，gzip会被自动解压缩
            var handler = new HttpClientHandler();
            //浏览器端无需配置
            if(!OperatingSystem.IsBrowser())
            {
                handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }

            using HttpClient Http = new(handler);
            WeatherLives? lives = await Lives(lat, lon,Http);
            List<WeatherForecastDay>? forecastDays = await ForecastDay(lat, lon, Http);
            List<WeatherForecastHours>? forecastHours = await ForecastHours(lat, lon, Http);
            WeatherData weatherData = new()
            {
                Lives = lives,
                ForecastHours = forecastHours,
                ForecastDays = forecastDays
            };
            return weatherData;

        }
        public async Task<List<WeatherForecastDay>?> ForecastDay(double lat, double lon,HttpClient Http)
        {
            var forecastUrl = $"https://devapi.qweather.com/v7/weather/7d?location={lon},{lat}&key={Key}";
            QWeatherResultForeastDay? forecast = null;
            try
            {
                forecast = await Http.GetFromJsonAsync<QWeatherResultForeastDay>(forecastUrl);
            }
            catch (Exception)
            {

                throw;
            }

            if (forecast is null)
                return null;

            bool state = Convert.ToInt16(forecast.code) != 200;
            if (state)
                return null;

            List<WeatherForecastDay> forecastDays = new();
            foreach (var item in forecast?.daily ?? default!)
            {
                WeatherForecastDay forecastDay = new()
                {
                    Weather = item.textDay,
                    Date = DateTime.ParseExact(item.fxDate, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture),
                    MaxTemp = item.tempMax,
                    MinTemp = item.tempMin
                };
                forecastDays.Add(forecastDay);
            }

            return forecastDays;
        }

        public async Task<List<WeatherForecastHours>?> ForecastHours(double lat, double lon,HttpClient Http)
        {
            var forecastUrl = $"https://devapi.qweather.com/v7/weather/24h?location={lon},{lat}&key={Key}";
            QWeatherResultForeastHours? forecast = null;
            try
            {
                forecast = await Http.GetFromJsonAsync<QWeatherResultForeastHours>(forecastUrl);
            }
            catch (Exception)
            {

                throw;
            }

            if (forecast is null)
                return null;

            bool state = Convert.ToInt16(forecast.code) != 200;
            if (state)
                return null;

            List<WeatherForecastHours> forecastHours = new();
            foreach (var item in forecast?.hourly ?? default!)
            {
                WeatherForecastHours forecastHour = new()
                {
                    Weather = item.text,
                    DateTime = item.fxTime,
                    Temp = item.temp
                };
                forecastHours.Add(forecastHour);
            }

            return forecastHours;
        }

        public async Task<WeatherLives?> Lives(double lat, double lon,HttpClient Http)
        {
            //获取天气实况
            var livesUrl = $"https://devapi.qweather.com/v7/weather/now?location={lon},{lat}&key={Key}";
            QWeatherResultLives? lives = null;
            try
            {
                lives = await Http.GetFromJsonAsync<QWeatherResultLives>(livesUrl);
            }
            catch (Exception)
            {

                throw;
            }

            if (lives is null)
                return null;

            bool state = Convert.ToInt16(lives.code) != 200;
            if (state)
                return null;

            WeatherLives weatherLives = new()
            {
                Weather = lives?.now?.text,
                Temp = lives?.now?.temp,
                WindDeg = lives?.now?.windDir,
                WindSpeed = lives?.now?.windSpeed,
                WindScale = lives?.now?.windScale,
                Humidity = lives?.now?.humidity,
                FeelsLike = lives?.now?.feelsLike,
                Pressure = lives?.now?.pressure,
                Visibility = lives?.now?.vis,
                Cloud = lives?.now?.cloud,
            };
            return weatherLives;
        }
        

    }
}
