using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather
{
    public class WeatherData
    {
        public WeatherLives? Lives { get; set; }
        public List<WeatherForecastHours>? ForecastHours { get; set; }
        public List<WeatherForecastDay>? ForecastDay { get; set; }

    }
}
