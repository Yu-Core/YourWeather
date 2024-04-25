using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public interface IWeatherService
    {
        Dictionary<WeatherSourceType, IWeatherSource> WeatherSources { get; }
        string GetWeatherIcon(string Weather);
        string GetWeatherIcon(string Weather, DateTime dateTime);
        Task<WeatherData> GetWeatherData(WeatherSourceType weather, Location location, string? key = null);
    }
}
