using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model;

namespace YourWeather.Service
{
    public class WeatherService
    {
        private readonly static List<WeatherSource> WeatherSources = new List<WeatherSource>()
        {
            new WeatherSource()
            {
                Name = "OpenWeather",
                Description = "100 万次/月 分钟级实时预报 天气云图",
                Key = "8e4e52f9f838382d6d566cc74a122426"
            },
            new WeatherSource()
            {
                Name = "和风天气",
                Description= "免费付费同权限，非商业无限免费",
                Key = "7b7fa181fa6041cabbad000e89ada12c"
            },
            new WeatherSource()
            {
                Name = "心知天气",
                Description="免费、轻便、专业",
                Key = "SJVanI-SKqrgxUj7L"
            },
            new WeatherSource()
            {
                Name = "VisualCrossing",
                Description="非开发者友好 50年历史气象数据免费调用",
                Key = "5SD8RVKRBSBGUKME3SN76M8TD"
            },
            new WeatherSource()
            {
                Name = "高德地图",
                Description= "稳定、免费、极简",
                Key = "4eff3072b68dcef66ab85b8be38efc0b"
            },
        };

        public List<WeatherSource> GetWeatherSources()
        {
            return WeatherSources;
        }
    }
}
