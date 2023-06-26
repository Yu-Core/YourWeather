using Microsoft.JSInterop;
using YourWeather.Shared;

namespace YourWeather.Rcl.Desktop.Services
{
    public class ThemeService : Rcl.Services.ThemeService
    {

        protected override void InternalNotifyStateChanged(ThemeType themeType)
        {
            base.InternalNotifyStateChanged(themeType);
            TitleBar.EnableDarkMode(themeType == ThemeType.Dark);
        }
    }
}
