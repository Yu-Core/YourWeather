using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Location;

namespace YourWeather.Model.Weather.WeatherSource
{
    public interface IWeatherSource
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }
        public WeatherData? WeatherData { get; set; }
        public Task<WeatherData> GetWeatherData(LocationData locationData);
    }
}
