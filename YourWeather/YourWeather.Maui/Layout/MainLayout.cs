using YourWeather.Maui.Services;
using YourWeather.Shared;

namespace YourWeather.Maui.Layout
{
    public class MainLayout : Rcl.Layout.MainLayout
    {
        protected override Task InitThemeServiceAsync()
        {
            return Task.CompletedTask;
        }

        protected override void ThemeChanged(ThemeType value)
        {
            base.ThemeChanged(value);

            TitleBarOrStatusBar.SetTitleBarOrStatusBar(value);
        }
    }
}
