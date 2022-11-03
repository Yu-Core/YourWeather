using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather.WeatherResult
{
    public class QWeatherResultLives
    {
        public string? code { get; set; }
        public DateTime updateTime { get; set; }
        public string? fxLink { get; set; }
        public QWeatherNow? now { get; set; }
    }

    public class QWeatherNow
    {
        public DateTime obsTime { get; set; }
        public string? temp { get; set; }
        public string? feelsLike { get; set; }
        public string? icon { get; set; }
        public string? text { get; set; }
        public string? wind360 { get; set; }
        public string? windDir { get; set; }
        public string? windScale { get; set; }
        public string? windSpeed { get; set; }
        public string? humidity { get; set; }
        public string? precip { get; set; }
        public string? pressure { get; set; }
        public string? vis { get; set; }
        public string? cloud { get; set; }
        public string? dew { get; set; }
    }


    public class QWeatherResultCity
    {
        public string? code { get; set; }
        public QWeatherLocation[]? location { get; set; }
    }

    public class QWeatherLocation
    {
        public string? name { get; set; }
    }


    public class QWeatherResultForeastDay
    {
        public string? code { get; set; }
        public string? updateTime { get; set; }
        public string? fxLink { get; set; }
        public QWeatherDaily[]? daily { get; set; }
    }

    public class QWeatherDaily
    {
        public string? fxDate { get; set; }
        public string? tempMax { get; set; }
        public string? tempMin { get; set; }
        public string? textDay { get; set; }
    }


    public class QWeatherResultForeastHours
    {
        public string? code { get; set; }
        public string? updateTime { get; set; }
        public string? fxLink { get; set; }
        public QWeatherHourly[]? hourly { get; set; }
    }


    public class QWeatherHourly
    {
        public DateTime fxTime { get; set; }
        public string? temp { get; set; }
        public string? text { get; set; }
    }


}
