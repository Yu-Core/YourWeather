using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather.WeatherSource
{
    public class VisualCrossingSource : IWeatherSource
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }

        public WeatherForecastDay? ForecastDay(double lat, double lon)
        {
            throw new NotImplementedException();
        }

        public WeatherForecastHours? ForecastHours(double lat, double lon)
        {
            throw new NotImplementedException();
        }

        public WeatherLives? Lives(double lat, double lon)
        {
            throw new NotImplementedException();
        }
    }
}
