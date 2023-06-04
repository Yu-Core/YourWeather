namespace YourWeather.Shared
{
    public interface IThemeService
    {
        event Action<ThemeType> OnChanged;
        Task SetThemeType(ThemeType themeType);
        Task<ThemeType> GetThemeType();
        Dictionary<string, ThemeType> ThemeTypes { get; }
    }
}
