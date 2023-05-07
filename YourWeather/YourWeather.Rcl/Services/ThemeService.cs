using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public abstract class ThemeService : IThemeService
    {
        protected ThemeType _themeType = ThemeType.Light;
        public bool Light => ThemeType == ThemeType.Light;

        public bool Dark => ThemeType == ThemeType.Dark;

        public ThemeType ThemeType
        {
            get => GetThemeType();
            set => SetThemeType(value);
        }

        public virtual Dictionary<string, ThemeType> ThemeTypes { get; } = new()
        {
            {"浅色",ThemeType.Light },
            {"深色",ThemeType.Dark }
        };

        public event Action<ThemeType>? OnChanged;

        protected virtual void SetThemeType(ThemeType value)
        {
            _themeType = value;
            NotifyStateChanged();
        }

        protected virtual ThemeType GetThemeType()
        {
            return _themeType;
        }

        protected virtual void NotifyStateChanged()
        {
            OnChanged?.Invoke(ThemeType);
        }

    }
}
