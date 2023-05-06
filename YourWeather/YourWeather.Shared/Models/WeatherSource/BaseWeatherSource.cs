namespace YourWeather.Shared
{
    public abstract class BaseWeatherSource : IWeatherSource
    {
        protected string? _defaultKey;
        protected string? _key;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Key
        {
            get
            {
                if(!string.IsNullOrEmpty(_key))
                {
                    return _key;
                }

                return _defaultKey;
            }
            set
            {
                _defaultKey ??= value;
                _key = value;
            }
        }
        public WeatherData? WeatherData { get; set; }

        public virtual Task<WeatherData> GetWeatherData(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
