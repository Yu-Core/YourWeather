namespace YourWeather.Shared
{
    public class OpenWeatherResultLives
    
    {
        public OpenWeatherWeather[]? weather { get; set; }
        public OpenWeatherMain? main { get; set; }
        public int visibility { get; set; }
        public OpenWeatherWind? wind { get; set; }
        public OpenWeatherClouds? clouds { get; set; }
        public int dt { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public int cod { get; set; }
    }

    public class OpenWeatherMain
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    public class OpenWeatherWind
    {
        public float speed { get; set; }
        public int deg { get; set; }
        public float gust { get; set; }
    }

    public class OpenWeatherClouds
    {
        public int all { get; set; }
    }


    public class OpenWeatherWeather
    {
        public int id { get; set; }
        public string? main { get; set; }
        public string? description { get; set; }
        public string? icon { get; set; }
    }

}
