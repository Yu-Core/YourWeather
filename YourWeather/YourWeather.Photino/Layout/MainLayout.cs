using YourWeather.Shared;

namespace YourWeather.Photino.Layout
{
    public class MainLayout : Rcl.Layout.MainLayout
    {
        protected override void ThemeChanged(ThemeType value)
        {
            base.ThemeChanged(value);
#if Windows
            TitleBar.EnableDarkMode(value == ThemeType.Dark);
#endif
        }
    }
}
