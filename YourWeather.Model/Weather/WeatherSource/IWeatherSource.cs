using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather.WeatherSource
{
    public interface IWeatherSource
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }
        public Task<WeatherLives?> Lives(double lat, double lon);
        public Task<List<WeatherForecastHours>?> ForecastHours(double lat, double lon);
        public Task<List<WeatherForecastDay>?> ForecastDay(double lat, double lon);
    }
}
