using Microsoft.JSInterop;
using YourWeather.Shared;

namespace YourWeather.Photino.Services
{
    public class ThemeService : Rcl.Services.ThemeService
    {
        public ThemeService(IJSRuntime jSRuntime) : base(jSRuntime)
        {
        }

        protected override void NotifyStateChanged(ThemeType themeType)
        {
            base.NotifyStateChanged(themeType);
#if Windows
            TitleBar.EnableDarkMode(themeType == ThemeType.Dark);
#endif
        }
    }
}
