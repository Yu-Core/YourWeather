using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Extend
{
    public static class WeatherExtend
    {
        private static Dictionary<string, string> VisualCrossingDic = new Dictionary<string, string>()
        {
            {"晴朗","晴" },
            {"部分多云","少云" },
            {"阴云密布","多云" },
        };
        public static string ToWindDir(this int windeg)
        {
            if (windeg < 0 || windeg > 360)
                return string.Empty;
            if (windeg > 337.5 || windeg <= 22.5)
                return "北风";
            if (windeg > 22.5 && windeg <= 67.5)
                return "东北风";
            if (windeg > 67.5 && windeg <= 112.5)
                return "东风";
            if (windeg > 112.5 && windeg <= 157.5)
                return "东南风";
            if (windeg > 157.5 && windeg <= 202.5)
                return "南风";
            if (windeg > 202.5 && windeg <= 247.5)
                return "西南风";
            if (windeg > 247.5 && windeg <= 292.5)
                return "西风";
            if (windeg > 292.5 && windeg <= 337.5)
                return "西北风";
            return string.Empty;
        }
        public static DateTime ToDateTime(this int timestamp)
        {
            string ID = TimeZoneInfo.Local.Id;
            DateTime start = new DateTime(1970, 1, 1) + TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            DateTime startTime = TimeZoneInfo.ConvertTime(start, TimeZoneInfo.FindSystemTimeZoneById(ID));
            return startTime.AddSeconds(timestamp);
        }
        public static string ToWeather(this string weather)
        {
            if (string.IsNullOrEmpty(weather))
                return "未知";

            weather = weather.Split(",")[0];
            weather = weather.Split("，")[0];
            if (VisualCrossingDic.ContainsKey(weather))
            {
                weather = VisualCrossingDic[weather];
            }

            return weather;
        }
    }
}
