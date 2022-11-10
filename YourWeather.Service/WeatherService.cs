using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model;
using YourWeather.Model.Weather.WeatherSource;

namespace YourWeather.Service
{
    public class WeatherService
    {
        public event Action? OnChange;
        public void SourceChange()
        {
            OnChange?.Invoke();
        }

        public string GetWeatherIcon(string Weather)
        {
            if (!string.IsNullOrEmpty(Weather))
            {
                if (StaticDataService.WeatherIconDayDic.ContainsKey(Weather))
                {
                    return StaticDataService.WeatherIconDayDic[Weather];
                }
            }

            return StaticDataService.WeatherIconShareDic["未知"];
        }
        public string GetWeatherIcon(string Weather, DateTime dateTime)
        {
            if (!string.IsNullOrEmpty(Weather))
            {
                int hour = Convert.ToInt16(dateTime.ToString("HH"));
                //此处判断白天黑夜，判定较简单，正常应该从天气api或其他服务器那里获取到日出日落时间
                if (hour >= 6 && hour < 18)
                {
                    if (StaticDataService.WeatherIconDayDic.ContainsKey(Weather))
                    {
                        return StaticDataService.WeatherIconDayDic[Weather];
                    }
                }
                else
                {
                    if (StaticDataService.WeatherIconNightDic.ContainsKey(Weather))
                    {
                        return StaticDataService.WeatherIconNightDic[Weather];
                    }
                }
            }

            return StaticDataService.WeatherIconShareDic["未知"];
        }
    }
}
