using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model;

namespace YourWeather.MAUIBlazor.Service
{
    public class SettingsService : ISettingsService
    {
        public SettingsService()
        {
            InitSettings();
        }
        public Settings Settings { get;private set; }

        public void InitSettings()
        {
            Settings = new Settings()
            {
                ThemeState = Model.Enum.ThemeState.System
            };
            Settings.OnChange += SaveSetings;
        }

        public void SaveSetings()
        {
            
        }
    }
}
