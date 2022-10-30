using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather
{
    public class WeatherForecastHours
    {
        public DateTime DateTime { get; set; }
        public string? Weather { get; set; }
        public string? Temp { get; set; }
    }
}
