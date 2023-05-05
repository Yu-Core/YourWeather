namespace YourWeather.Shared
{
    public class WeatherData
    {
        public WeatherLives? Lives { get; set; }
        public List<WeatherForecastHours>? ForecastHours { get; set; }
        public List<WeatherForecastDay>? ForecastDays { get; set; }

    }
}
