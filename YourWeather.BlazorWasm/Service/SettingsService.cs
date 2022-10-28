using YourWeather.IService;
using YourWeather.Model;

namespace YourWeather.BlazorWasm.Service
{
    public class SettingsService : ISettingsService
    {
        public SettingsService()
        {
            InitSettings();
        }
        public Settings Settings { get; private set; }

        public void InitSettings()
        {
            Settings = new Settings()
            {
                ThemeState = Model.Enum.ThemeState.Light,
                WeatherSource = new()
                {
                    Name = "OpenWeather",
                    Description = "100 万次/月 分钟级实时预报 天气云图",
                    Key = "8e4e52f9f838382d6d566cc74a122426"
                }
            };
            Settings.OnChange += SaveSetings;
        }

        public void SaveSetings()
        {
            
        }
    }
}
