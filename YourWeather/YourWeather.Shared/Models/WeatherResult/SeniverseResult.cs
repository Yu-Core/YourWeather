namespace YourWeather.Shared
{
    public class SeniverseResultLives
    {
        public SeniverseLivesResult[]? results { get; set; }
    }

    public class SeniverseLivesResult
    {
        public SeniverseLocation? location { get; set; }
        public SeniverseNow? now { get; set; }
        public DateTime last_update { get; set; }
    }

    public class SeniverseLocation
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? country { get; set; }
        public string? path { get; set; }
        public string? timezone { get; set; }
        public string? timezone_offset { get; set; }
    }

    public class SeniverseNow
    {
        public string? text { get; set; }
        public string? code { get; set; }
        public string? temperature { get; set; }
    }


    public class SeniverseResultForeastDay
    {
        public ForeastDayResult[]? results { get; set; }
    }

    public class ForeastDayResult
    {
        public SeniverseLocation? location { get; set; }
        public SeniverseDaily[]? daily { get; set; }
        public DateTime last_update { get; set; }
    }

    public class SeniverseDaily
    {
        public string? date { get; set; }
        public string? text_day { get; set; }
        public string? code_day { get; set; }
        public string? text_night { get; set; }
        public string? code_night { get; set; }
        public string? high { get; set; }
        public string? low { get; set; }
        public string? rainfall { get; set; }
        public string? precip { get; set; }
        public string? wind_direction { get; set; }
        public string? wind_direction_degree { get; set; }
        public string? wind_speed { get; set; }
        public string? wind_scale { get; set; }
        public string? humidity { get; set; }
    }


}
