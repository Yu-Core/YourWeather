using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Shared
{
    public class Location
    {
        public Location() { }
        public Location(string? name, string? info, double lat, double lon)
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
