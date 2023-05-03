namespace YourWeather.Shared
{
    public abstract class BaseWeatherSource : IWeatherSource
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }
        public WeatherData? WeatherData { get; set; }

        public virtual Task<WeatherData> GetWeatherData(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
