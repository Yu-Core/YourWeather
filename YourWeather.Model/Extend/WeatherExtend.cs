using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Extend
{
    public static class WeatherExtend
    {
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

    }
}
