namespace YourWeather.Shared
{

    public class VisualCrossingResult
    {
        public VisualCrossingDay[]? days { get; set; }
        public VisualCrossingCurrentconditions? currentConditions { get; set; }
    }

    public class VisualCrossingCurrentconditions
    {
        public string? datetime { get; set; }
        public int datetimeEpoch { get; set; }
        public float temp { get; set; }
        public float feelslike { get; set; }
        public float humidity { get; set; }
        public object? windgust { get; set; }
        public float windspeed { get; set; }
        public float winddir { get; set; }
        public float pressure { get; set; }
        public float visibility { get; set; }
        public float cloudcover { get; set; }
        public string? conditions { get; set; }
    }

    public class VisualCrossingDay
    {
        public string? datetime { get; set; }
        public int datetimeEpoch { get; set; }
        public float tempmax { get; set; }
        public float tempmin { get; set; }
        public float temp { get; set; }
        public string? conditions { get; set; }
        public VisualCrossingHour[]? hours { get; set; }
    }

    public class VisualCrossingHour
    {
        public string? datetime { get; set; }
        public int datetimeEpoch { get; set; }
        public float temp { get; set; }
        public string? conditions { get; set; }
    }

}
