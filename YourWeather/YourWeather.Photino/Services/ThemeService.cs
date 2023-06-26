using Microsoft.JSInterop;
using YourWeather.Shared;

namespace YourWeather.Photino.Services
{
    public class ThemeService : Rcl.Services.ThemeService
    {
        protected override void InternalNotifyStateChanged(ThemeType themeType)
        {
            base.InternalNotifyStateChanged(themeType);
#if Windows
            TitleBar.EnableDarkMode(themeType == ThemeType.Dark);
#endif
        }
    }
}
