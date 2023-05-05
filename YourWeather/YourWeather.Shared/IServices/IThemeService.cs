namespace YourWeather.Shared
{
    public interface IThemeService
    {
        event Action<ThemeType> OnChanged;
        bool Light { get; }
        bool Dark { get; }
        ThemeType ThemeType { get; set; }
        Dictionary<string, ThemeType> ThemeTypes { get; }
    }
}
