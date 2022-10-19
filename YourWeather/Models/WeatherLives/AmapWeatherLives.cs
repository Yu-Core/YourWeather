using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Models.WeatherLives
{
    public class AmapWeatherLives
    {
        public string Status { get; set; }
        public string Count { get; set; }
        public string Info { get; set; }
        public string Infocode { get; set; }
        public Life[] Lives { get; set; }
    }

    public class Life
    {
        public string ProvinceProvince { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Adcode { get; set; }
        public string Weather { get; set; }
        public string Temperature { get; set; }
        public string Winddirection { get; set; }
        public string Windpower { get; set; }
        public string Humidity { get; set; }
        public string Reporttime { get; set; }
    }

}
