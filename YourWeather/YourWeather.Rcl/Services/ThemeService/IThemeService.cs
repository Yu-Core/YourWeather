using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public interface IThemeService
    {
        event Action<ThemeType>? OnChanged;
        ThemeType RealTheme { get; }
        Task SetThemeAsync(ThemeType theme);
    }
}
