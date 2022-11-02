using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Enum;
using YourWeather.Model.Item;

namespace YourWeather.Model
{
    public class Settings
    {
        private int _weatherSource;
        public int WeatherSource
        {
            get => _weatherSource;
            set
            {
                _weatherSource = value;
                NotifyStateChanged();
            }
        }
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
        private int _codeSource;
        public int CodeSource
        {
            get => _codeSource;
            set
            {
                _codeSource = value;
                NotifyStateChanged();
            }
        }
        private int _language;
        public int Language
        {
            get => _language;
            set 
            { 
                _language = value;
                NotifyStateChanged();
            }
        }
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
