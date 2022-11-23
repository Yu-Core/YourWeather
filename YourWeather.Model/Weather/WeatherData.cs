using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Location;

namespace YourWeather.Model.Weather
{
    public class WeatherData
    {
        public LocationData LocationData { get; set; }
        public WeatherLives? Lives { get; set; }
        public List<WeatherForecastHours>? ForecastHours { get; set; }
        public List<WeatherForecastDay>? ForecastDays { get; set; }

    }
}
