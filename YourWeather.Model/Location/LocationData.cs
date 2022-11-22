using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Location
{
    public class LocationData
    {
        public LocationData() { }
        public LocationData(string? name, string? info, double lat, double lon)
        {
            Name = name;
            Info = info;
            Lat = lat;
            Lon = lon;
        }

        public string? Name { get; set; }
        public string? Info { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
