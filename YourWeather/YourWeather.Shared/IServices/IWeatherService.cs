namespace YourWeather.Shared
{
    public interface IWeatherService
    {
        string GetWeatherIcon(string Weather);
        string GetWeatherIcon(string Weather,DateTime dateTime);
        Task<WeatherData> GetWeatherData(WeatherSourceType weather,Location location);
    }
}
