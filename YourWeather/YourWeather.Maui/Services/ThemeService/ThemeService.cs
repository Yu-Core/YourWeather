using YourWeather.Rcl.Services;
using YourWeather.Shared;

namespace YourWeather.Maui.Services
{
    public class ThemeService : IThemeService
    {
        private ThemeType? _theme;

        public event Action<ThemeType>? OnChanged;

        public ThemeType RealTheme => _theme switch
        {
            ThemeType.System => Application.Current!.RequestedTheme == AppTheme.Dark ? ThemeType.Dark : ThemeType.Light,
            ThemeType.Dark => ThemeType.Dark,
            _ => ThemeType.Light
        };

        public Task SetThemeAsync(ThemeType theme)
        {
            if (_theme == theme)
            {
                return Task.CompletedTask;
            }

            //跟随系统主题改变
            if (theme == ThemeType.System)
            {
                Application.Current!.RequestedThemeChanged += HandleAppThemeChanged;
            }
            //取消跟随系统主题改变
            else if (_theme == ThemeType.System)
            {
                Application.Current!.RequestedThemeChanged -= HandleAppThemeChanged;
            }

            _theme = theme;

            InternalNotifyStateChanged();
            return Task.CompletedTask;
        }

        private void HandleAppThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            InternalNotifyStateChanged();
        }

        private void InternalNotifyStateChanged()
        {
            OnChanged?.Invoke(RealTheme);
        }
    }
}
