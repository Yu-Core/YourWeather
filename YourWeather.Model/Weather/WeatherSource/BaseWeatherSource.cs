using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Location;

namespace YourWeather.Model.Weather.WeatherSource
{
    public class BaseWeatherSource : IWeatherSource
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }
        public WeatherData? WeatherData { get; set; }

        public async Task<WeatherData> GetWeatherData(LocationData location)
        {
            if (WeatherData != null && WeatherData.Lives != null)
            {
                if(WeatherData.LocationData!= null && WeatherData.LocationData.Info == location.Info)
                {
                    TimeSpan timeSpan = DateTime.Now - WeatherData.Lives.LastUpdate;
                    if (timeSpan.TotalMinutes < 10)
                    {
                        return WeatherData;
                    }
                }
            }
            WeatherData = await ReceiveWeatherData(location.Lat, location.Lon);
            WeatherData.LocationData = location;
            return WeatherData;
        }

        protected virtual Task<WeatherData> ReceiveWeatherData(double lat, double lon)
        {
            WeatherData weatherData = new WeatherData();
            return Task.FromResult(weatherData);
        }
    }
}
