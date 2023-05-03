using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public class WeatherService : IWeatherService
    {
        public Task<WeatherData> GetWeatherData(WeatherSourceType weather,Location location)
        {
            if(!WeatherSources.ContainsKey(weather))
            {
                return default!;
            }

            return WeatherSources[weather].GetWeatherData(location);
        }

        public string GetWeatherIcon(string Weather)
        {
            if (!string.IsNullOrEmpty(Weather))
            {
                if (WeatherIconDayDic.ContainsKey(Weather))
                {
                    return WeatherIconDayDic[Weather];
                }
            }

            return WeatherIconShareDic["未知"];
        }
        public string GetWeatherIcon(string Weather, DateTime dateTime)
        {
            if (!string.IsNullOrEmpty(Weather))
            {
                int hour = Convert.ToInt16(dateTime.ToString("HH"));
                //此处判断白天黑夜，判定较简单，正常应该从天气api或其他服务器那里获取到日出日落时间
                if (hour >= 6 && hour < 18)
                {
                    if (WeatherIconDayDic.ContainsKey(Weather))
                    {
                        return WeatherIconDayDic[Weather];
                    }
                }
                else
                {
                    if (WeatherIconNightDic.ContainsKey(Weather))
                    {
                        return WeatherIconNightDic[Weather];
                    }
                }
            }

            return WeatherIconShareDic["未知"];
        }

        protected static Dictionary<WeatherSourceType, IWeatherSource> WeatherSources = new()
        {
            { 
                WeatherSourceType.OpenWeather,
                new OpenWeatherSource()
                {
                    Name = "OpenWeather",
                    Description = "100 万次/月 数据较少",
                    Key = "8e4e52f9f838382d6d566cc74a122426"
                } 
            },
            { 
                WeatherSourceType.QWeather,
                new QWeatherSource()
                {
                    Name = "和风天气",
                    Description= "1000次调用/天，数据较全",
                    Key = "7b7fa181fa6041cabbad000e89ada12c"
                } 
            },
            {
                WeatherSourceType.Seniverse,
                new SeniverseSource()
                {
                    Name = "心知天气",
                    Description="调用次数无限制，数据较少，没有逐小时预报",
                    Key = "SJVanI-SKqrgxUj7L"
                } 
            },
            {
                WeatherSourceType.VisualCrossing,
                new VisualCrossingSource()
                {
                    Name = "VisualCrossing",
                    Description ="1000次调用/天，数据较全",
                    Key = "5SD8RVKRBSBGUKME3SN76M8TD"
                } 
            },
            {
                WeatherSourceType.Amap,
                new AmapSource()
                {
                    Name = "高德地图",
                    Description= "30万次调用/日，数据较少，没有逐小时预报",
                    Key = "4eff3072b68dcef66ab85b8be38efc0b"
                } 
            },
        };
        protected readonly static Dictionary<string, string> WeatherIconShareDic = new Dictionary<string, string>()
        {
            {"阴","qi-104-fill" },
            {"雷阵雨","qi-302-fill" },
            {"强雷阵雨","qi-303-fill" },
            {"雷阵雨伴有冰雹","qi-304-fill" },
            {"小雨","qi-305-fill" },
            {"中雨","qi-306-fill" },
            {"大雨","qi-307-fill" },
            {"极端降雨","qi-308-fill" },
            {"毛毛雨/细雨","qi-309-fill" },
            {"暴雨","qi-310-fill" },
            {"大暴雨","qi-311-fill" },
            {"特大暴雨","qi-312-fill" },
            {"冻雨","qi-313-fill" },
            {"小到中雨","qi-314-fill" },
            {"中到大雨","qi-315-fill" },
            {"大到暴雨","qi-316-fill" },
            {"暴雨到大暴雨","qi-317-fill" },
            {"大暴雨到特大暴雨","qi-318-fill" },
            {"雨","qi-399-fill" },
            {"小雪","qi-400-fill" },
            {"中雪","qi-401-fill" },
            {"大雪","qi-402-fill" },
            {"暴雪","qi-403-fill" },
            {"雨夹雪","qi-404-fill" },
            {"雨雪天气","qi-405-fill" },
            {"小到中雪","qi-408-fill" },
            {"中到大雪","qi-409-fill" },
            {"大到暴雪","qi-410-fill" },
            {"雪","qi-499-fill" },
            {"薄雾","qi-500-fill" },
            {"雾","qi-501-fill" },
            {"霾","qi-502-fill" },
            {"扬沙","qi-503-fill" },
            {"浮尘","qi-504-fill" },
            {"沙尘暴","qi-507-fill" },
            {"强沙尘暴","qi-508-fill" },
            {"浓雾","qi-509-fill" },
            {"强浓雾","qi-510-fill" },
            {"中度霾","qi-511-fill" },
            {"重度霾","qi-512-fill" },
            {"严重霾","qi-513-fill" },
            {"大雾","qi-514-fill" },
            {"特强浓雾","qi-515-fill" },
            {"热","qi-900-fill" },
            {"冷","qi-901-fill" },
            {"未知","qi-999" },

        };
        protected readonly static Dictionary<string, string> WeatherIconDayDic = new Dictionary<string, string>(WeatherIconShareDic)
        {
            {"晴","qi-100-fill" },
            {"多云","qi-101-fill" },
            {"少云","qi-102-fill" },
            {"晴间多云","qi-103-fill" },
            {"阵雨","qi-300-fill" },
            {"强阵雨","qi-301-fill" },
            {"阵雨夹雪","qi-406-fill" },
            {"阵雪","qi-407-fill" },
        };
        protected readonly static Dictionary<string, string> WeatherIconNightDic = new Dictionary<string, string>(WeatherIconShareDic)
        {
            {"晴","qi-150-fill" },
            {"多云","qi-151-fill" },
            {"少云","qi-152-fill" },
            {"晴间多云","qi-153-fill" },
            {"阵雨","qi-350-fill" },
            {"强阵雨","qi-351-fill" },
            {"阵雨夹雪","qi-456-fill" },
            {"阵雪","qi-457-fill" },
        };
    }
}
