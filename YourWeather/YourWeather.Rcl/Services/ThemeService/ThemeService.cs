using BlazorToolkit;
using BlazorToolkit.Essentials;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public abstract class ThemeService : IThemeService
    {
        public event Action<ThemeType>? OnChanged;
        protected ThemeType? _themeType;
        public virtual Dictionary<string, ThemeType> ThemeTypes { get; } = new()
        {
            {"跟随系统",ThemeType.System },
            {"浅色",ThemeType.Light },
            {"深色",ThemeType.Dark }
        };

        public virtual async Task SetThemeType(ThemeType value)
        {
            if (_themeType == value)
            {
                return;
            }

            _themeType = value;
            if (value == ThemeType.System)
            {
                Theme.Default.SystemThemeChanged += NotifyStateChanged;
            }
            else
            {
                Theme.Default.SystemThemeChanged -= NotifyStateChanged;
            }

            ThemeType themeType = await GetThemeType();
            InternalNotifyStateChanged(themeType);
        }

        public virtual async Task<ThemeType> GetThemeType()
        {
            if (_themeType == ThemeType.System)
            {
                var theme = await Theme.Default.GetSystemThemeAsync();
                return theme == AppTheme.Dark ? ThemeType.Dark : ThemeType.Light;
            }

            return _themeType ?? ThemeType.Light;
        }

        private void NotifyStateChanged(AppTheme value)
        {
            InternalNotifyStateChanged(value == AppTheme.Dark ? ThemeType.Dark : ThemeType.Light);
        }

        protected virtual void InternalNotifyStateChanged(ThemeType value)
        {
            OnChanged?.Invoke(value);
        }
    }
}
