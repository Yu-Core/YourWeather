using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Razor.Extend
{
    public static class DateTimeExtend
    {
        static readonly string[] Day = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
        public static string ToWeek(this DayOfWeek dayOfWeek)
        {
            return Day[Convert.ToInt16(dayOfWeek)];
        }
    }
}
