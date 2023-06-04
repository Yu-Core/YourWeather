using Microsoft.JSInterop;
using YourWeather.Shared;

namespace YourWeather.Rcl.Desktop.Services
{
    public class ThemeService : Rcl.Services.ThemeService
    {
        public ThemeService(IJSRuntime jSRuntime) : base(jSRuntime)
        {
        }

        protected override void NotifyStateChanged(ThemeType themeType)
        {
            base.NotifyStateChanged(themeType);
            TitleBar.EnableDarkMode(themeType == ThemeType.Dark);
        }
    }
}
