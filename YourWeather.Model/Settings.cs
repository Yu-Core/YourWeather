using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Enum;

namespace YourWeather.Model
{
    public class Settings
    {
        public WeatherSource? WeatherSource;
        private ThemeState _themeState;
        public ThemeState ThemeState
        {
            get => _themeState;
            set
            {
                _themeState = value;
                NotifyStateChanged();
            }
        }
        private int _codeSourceState;
        public int CodeSourceState
        {
            get => _codeSourceState;
            set
            {
                _codeSourceState = value;
                NotifyStateChanged();
            }
        }
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
