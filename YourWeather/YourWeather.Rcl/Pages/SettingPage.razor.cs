using YourWeather.Rcl.Components;
using YourWeather.Rcl.Services;
using YourWeather.Shared;

namespace YourWeather.Rcl.Pages
{
    public partial class SettingPage : PageComponentBase
    {
        private bool ShowThemeType;
        private bool ShowWeatherSource;
        private ThemeType ThemeType;
        private WeatherSourceType WeatherSourceType;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Title = "设置";
            await LoadSettings();
        }

        private Dictionary<string, ThemeType> ThemeTypes => ThemeService.ThemeTypes;
        private Dictionary<WeatherSourceType, IWeatherSource> WeatherSources => WeatherService.WeatherSources;

        private async Task ThemeTypeChanged(ThemeType value)
        {
            ThemeType = value;
            ThemeService.ThemeType = value;
            await SettingsService.Save(SettingType.Theme, (int)value);
        }

        private async Task LoadSettings()
        {
            int themeType = await SettingsService.Get<int>(SettingType.Theme);
            ThemeType = (ThemeType)themeType;
            int weatherSourceType = await SettingsService.Get<int>(SettingType.WeatherSource);
            WeatherSourceType = (WeatherSourceType)weatherSourceType;
        }

        private async Task WeatherSourceChanged(WeatherSourceType value)
        {
            WeatherSourceType = value;
            await SettingsService.Save(SettingType.WeatherSource, WeatherSourceType);
        }
    }
}
