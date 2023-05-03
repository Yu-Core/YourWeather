namespace YourWeather.Shared
{
    public interface IWeatherSource
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }
        public WeatherData? WeatherData { get; set; }
        public Task<WeatherData> GetWeatherData(Location location);
    }
}
