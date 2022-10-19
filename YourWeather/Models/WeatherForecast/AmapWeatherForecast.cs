using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Models.WeatherForecast
{
    public class AmapWeatherForecast
    {
        public string Status { get; set; }
        public string Count { get; set; }
        public string Info { get; set; }
        public string Infocode { get; set; }
        public Forecast[] Forecasts { get; set; }
    }

    public class Forecast
    {
        public string City { get; set; }
        public string Adcode { get; set; }
        public string Province { get; set; }
        public string Reporttime { get; set; }
        public Cast[] Casts { get; set; }
    }

    public class Cast
    {
        public string Date { get; set; }
        public string Week { get; set; }
        public string Dayweather { get; set; }
        public string Nightweather { get; set; }
        public string Daytemp { get; set; }
        public string Nighttemp { get; set; }
        public string Daywind { get; set; }
        public string Nightwind { get; set; }
        public string Daypower { get; set; }
        public string Nightpower { get; set; }
    }

}
