using YourWeather.Shared;

namespace YourWeather.Rcl.Desktop.Layout
{
    public class MainLayout : Rcl.Layout.MainLayout
    {
        protected override void ThemeChanged(ThemeType value)
        {
            base.ThemeChanged(value);

            TitleBar.EnableDarkMode(value == ThemeType.Dark);
        }
    }
}
