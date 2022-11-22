using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Enum;
using YourWeather.Model.Item;
using YourWeather.Model.Location;

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
        private bool _showLives = true;
        public bool ShowLives
        {
            get => _showLives;
            set
            {
                _showLives = value;
                NotifyStateChanged();
            }
        }
        private bool _showForeastDays = true;
        public bool ShowForeastDays
        {
            get => _showForeastDays;
            set
            {
                _showForeastDays = value;
                NotifyStateChanged();
            }
        }
        private bool _showForeastHours = true;
        public bool ShowForeastHour
        {
            get => _showForeastHours;
            set
            {
                _showForeastHours = value;
                NotifyStateChanged();
            }
        }
        private bool _showLivesInfo = true;
        public bool ShowLivesInfo
        {
            get => _showLivesInfo;
            set
            {
                _showLivesInfo = value;
                NotifyStateChanged();
            }
        }
        public List<LocationData> LocationDatas { get; private set; } = new();
        public void AddLocationData(LocationData locationData)
        {
            LocationDatas.Add(locationData);
            NotifyStateChanged();
        }
        public void RemoveLocationData(LocationData locationData)
        {
            LocationDatas.Remove(locationData);
            NotifyStateChanged();
        }

        public event Action OnChanged;
        private void NotifyStateChanged() => OnChanged?.Invoke();
    }
}
