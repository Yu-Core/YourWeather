using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather
{
    public class WeatherForecastDay
    {
        public string Week { get; set; }
        public string? Weather { get; set; }
        public string? MinTemp { get; set; }
        public string? MaxTemp { get; set; }
    }
}
