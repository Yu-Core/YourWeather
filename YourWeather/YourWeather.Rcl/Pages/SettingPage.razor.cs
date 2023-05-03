using YourWeather.Rcl.Components;
using YourWeather.Shared;

namespace YourWeather.Rcl.Pages
{
    public partial class SettingPage : PageComponentBase
    {
        private bool ShowLanguage;
        private bool ShowThemeType;
        private ThemeType ThemeType;
        private string? Language;
        public Dictionary<string, string> Languages { get; } = new()
        {
            {"简体中文","zh-CN" },
            {"English","en-US" }
        };

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Title = "设置";
            await LoadSettings();
        }

        private Dictionary<string, ThemeType> ThemeTypes => ThemeService.ThemeTypes;

        private async Task ThemeTypeChanged(ThemeType value)
        {
            ThemeType = value;
            ThemeService.ThemeType = value;
            await SettingsService.Save(SettingType.Theme, (int)value);
        }

        private async Task LoadSettings()
        {
            Language = await SettingsService.Get<string>(SettingType.Language);
            int themeType = await SettingsService.Get<int>(SettingType.Theme);
            ThemeType = (ThemeType)themeType;
        }

        private async Task LanguageChanged(string value)
        {
            Language = value;
            I18n.SetCulture(new(value));
            await SettingsService.Save(SettingType.Language, Language);
        }
    }
}
