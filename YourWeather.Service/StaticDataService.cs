using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Item;
using YourWeather.Model.Weather.WeatherSource;

namespace YourWeather.Service
{
    public static class StaticDataService
    {
        private const string mdi_gitee = "m12.18134,22.14583q2.09582,0 3.93968,-0.78836t3.24108,-2.17226q1.39721,-1.38389 2.19317,-3.21017t0.79595,-3.90212q0,-2.07584 -0.79595,-3.90212t-2.19317,-3.21017q-1.39721,-1.38389 -3.24108,-2.17226t-3.93968,-0.78836q-2.10727,0 -3.95114,0.78836t-3.24108,2.17226q-1.39721,1.38389 -2.19317,3.21017t-0.79595,3.90212q0,2.07584 0.79595,3.90212t2.19317,3.21017q1.39721,1.38389 3.24108,2.17226t3.95114,0.78836zm2.27906,-4.53735l-7.43272,0q-0.19469,0 -0.3493,-0.15881t-0.15461,-0.3403l0,-6.98752q0,-1.00956 0.49819,-1.85464t1.34568,-1.35553q0.84749,-0.51045 1.90113,-0.51045l7.05478,0q0.19469,0 0.3493,0.15881t0.15461,0.35164l0,1.25911q0,0.18149 -0.15461,0.3403t-0.3493,0.15881l-7.05478,0q-0.61844,0 -1.07082,0.44806t-0.45238,1.06061l0,4.7869q0,0.19284 0.16034,0.34597t0.34358,0.15314l4.76427,0q0.62989,0 1.08227,-0.44806t0.45238,-1.06061l0,-0.24955q0,-0.19284 -0.16034,-0.34597t-0.35503,-0.15314l-3.49303,0q-0.19469,0 -0.3493,-0.15881t-0.15461,-0.35164l0,-1.25911q0,-0.18149 0.15461,-0.3403t0.3493,-0.15881l5.78355,0q0.19469,0 0.3493,0.15881t0.15461,0.3403l0,2.83584q0,1.37255 -0.99065,2.35375t-2.37641,0.9812z";
        private const string githubUrl = "https://github.com/Yu-Core/YourWeather";
        private const string giteeUrl = "https://gitee.com/Yu-core/YourWeather";

        public readonly static List<CodeSourceItem> CodeSourceItems = new List<CodeSourceItem>()
        {
            new CodeSourceItem("Github",githubUrl,"mdi-github"),
            new CodeSourceItem("Gitee",giteeUrl,mdi_gitee)
        };
        public readonly static List<LanguageItem> LanguageItems = new List<LanguageItem>()
        {
            new LanguageItem("中文","zh-CN"),
            new LanguageItem("English","en-US")
        };
        public readonly static List<IWeatherSource> WeatherSources = new List<IWeatherSource>()
        {
            new OpenWeatherSource()
            {
                Name = "OpenWeather",
                Description = "100 万次/月 数据较少",
                Key = "8e4e52f9f838382d6d566cc74a122426"
            },
            new QWeatherSource()
            {
                Name = "和风天气",
                Description= "1000次调用/天，数据较全",
                Key = "7b7fa181fa6041cabbad000e89ada12c"
            },
            new SeniverseSource()
            {
                Name = "心知天气",
                Description="调用次数无限制，数据较少，没有逐小时预报",
                Key = "SJVanI-SKqrgxUj7L"
            },
            new VisualCrossingSource()
            {
                Name = "VisualCrossing",
                Description ="1000次调用/天，数据较全",
                Key = "5SD8RVKRBSBGUKME3SN76M8TD"
            },
            new AmapSource()
            {
                Name = "高德地图",
                Description= "30万次调用/日，数据较少，没有逐小时预报",
                Key = "4eff3072b68dcef66ab85b8be38efc0b"
            },
        };
        public readonly static Dictionary<string, string> WeatherIconShareDic = new Dictionary<string, string>()
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
        public readonly static Dictionary<string, string> WeatherIconDayDic = new Dictionary<string, string>(WeatherIconShareDic)
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
        public readonly static Dictionary<string, string> WeatherIconNightDic = new Dictionary<string, string>(WeatherIconShareDic)
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
