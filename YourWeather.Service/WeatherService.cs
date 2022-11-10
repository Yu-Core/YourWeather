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
    }
}
