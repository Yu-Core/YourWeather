using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather
{
    public interface IWeatherSource
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }
        public string? LivesWeatherUrl();
        public string? LivesWeatherUrl(string city);
        public string? LivesWeatherUrl(int cityCode);
    }
}
