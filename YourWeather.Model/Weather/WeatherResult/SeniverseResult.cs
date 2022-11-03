using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather.WeatherResult
{
    public class SeniverseResultLives
    {
        public LivesResult[]? results { get; set; }
    }

    public class LivesResult
    {
        public Location? location { get; set; }
        public Now? now { get; set; }
        public DateTime last_update { get; set; }
    }

    public class Location
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? country { get; set; }
        public string? path { get; set; }
        public string? timezone { get; set; }
        public string? timezone_offset { get; set; }
    }

    public class Now
    {
        public string? text { get; set; }
        public string? code { get; set; }
        public string? temperature { get; set; }
    }


    public class SeniverseResultForeastDay
    {
        public ForeastDayResult[] results { get; set; }
    }

    public class ForeastDayResult
    {
        public Location location { get; set; }
        public Daily[] daily { get; set; }
        public DateTime last_update { get; set; }
    }

    public class Daily
    {
        public string date { get; set; }
        public string text_day { get; set; }
        public string code_day { get; set; }
        public string text_night { get; set; }
        public string code_night { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string rainfall { get; set; }
        public string precip { get; set; }
        public string wind_direction { get; set; }
        public string wind_direction_degree { get; set; }
        public string wind_speed { get; set; }
        public string wind_scale { get; set; }
        public string humidity { get; set; }
    }


}
