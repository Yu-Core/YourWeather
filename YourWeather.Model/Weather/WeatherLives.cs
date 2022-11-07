using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather
{
    public class WeatherLives
    {
        /// <summary>
        /// 城市名
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// 天气描述
        /// </summary>
        public string? Weather { get; set; }
        /// <summary>
        /// 温度，摄氏度
        /// </summary>
        public string? Temp { get; set; }
        /// <summary>
        /// 体感温度
        /// </summary>
        public string? FeelsLike { get; set; }
        /// <summary>
        /// 最低温度
        /// </summary>
        public string? MinTemp { get; set; }
        /// <summary>
        /// 最高温度
        /// </summary>
        public string? MaxTemp { get; set; }
        /// <summary>
        /// 湿度
        /// </summary>
        public string? Humidity { get; set; }
        /// <summary>
        /// 风速
        /// </summary>
        public string? WindSpeed { get; set; }
        /// <summary>
        /// 风向
        /// </summary>
        public string? WindDeg { get; set; }
        /// <summary>
        /// 能见度
        /// </summary>
        public string? Visibility { get; set; }
        /// <summary>
        /// 大气压强
        /// </summary>
        public string? Pressure { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
