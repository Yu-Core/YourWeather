using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather.WeatherResult
{

    public class VisualCrossingResult
    {
        public VisualCrossingDay[] days { get; set; }
        public VisualCrossingCurrentconditions currentConditions { get; set; }
    }

    public class VisualCrossingCurrentconditions
    {
        public string datetime { get; set; }
        public int datetimeEpoch { get; set; }
        public float temp { get; set; }
        public float feelslike { get; set; }
        public float humidity { get; set; }
        public float dew { get; set; }
        public float precip { get; set; }
        public object precipprob { get; set; }
        public float snow { get; set; }
        public float snowdepth { get; set; }
        public object preciptype { get; set; }
        public object windgust { get; set; }
        public float windspeed { get; set; }
        public float winddir { get; set; }
        public float pressure { get; set; }
        public float visibility { get; set; }
        public float cloudcover { get; set; }
        public float solarradiation { get; set; }
        public object solarenergy { get; set; }
        public float uvindex { get; set; }
        public string conditions { get; set; }
        public string icon { get; set; }
        public string[] stations { get; set; }
        public string sunrise { get; set; }
        public int sunriseEpoch { get; set; }
        public string sunset { get; set; }
        public int sunsetEpoch { get; set; }
        public float moonphase { get; set; }
    }

    public class VisualCrossingDay
    {
        public string datetime { get; set; }
        public int datetimeEpoch { get; set; }
        public float tempmax { get; set; }
        public float tempmin { get; set; }
        public float temp { get; set; }
        public float feelslikemax { get; set; }
        public float feelslikemin { get; set; }
        public float feelslike { get; set; }
        public float dew { get; set; }
        public float humidity { get; set; }
        public float precip { get; set; }
        public float precipprob { get; set; }
        public float precipcover { get; set; }
        public string[] preciptype { get; set; }
        public float snow { get; set; }
        public float snowdepth { get; set; }
        public float windgust { get; set; }
        public float windspeed { get; set; }
        public float winddir { get; set; }
        public float pressure { get; set; }
        public float cloudcover { get; set; }
        public float visibility { get; set; }
        public float solarradiation { get; set; }
        public float solarenergy { get; set; }
        public float uvindex { get; set; }
        public float severerisk { get; set; }
        public string sunrise { get; set; }
        public int sunriseEpoch { get; set; }
        public string sunset { get; set; }
        public int sunsetEpoch { get; set; }
        public float moonphase { get; set; }
        public string conditions { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string[] stations { get; set; }
        public string source { get; set; }
        public VisualCrossingHour[] hours { get; set; }
    }

    public class VisualCrossingHour
    {
        public string datetime { get; set; }
        public int datetimeEpoch { get; set; }
        public float temp { get; set; }
        public float feelslike { get; set; }
        public float humidity { get; set; }
        public float dew { get; set; }
        public float precip { get; set; }
        public float precipprob { get; set; }
        public float snow { get; set; }
        public float snowdepth { get; set; }
        public string[] preciptype { get; set; }
        public float windgust { get; set; }
        public float windspeed { get; set; }
        public float winddir { get; set; }
        public float pressure { get; set; }
        public float visibility { get; set; }
        public float cloudcover { get; set; }
        public float solarradiation { get; set; }
        public float? solarenergy { get; set; }
        public float uvindex { get; set; }
        public float severerisk { get; set; }
        public string conditions { get; set; }
        public string icon { get; set; }
        public string[] stations { get; set; }
        public string source { get; set; }
    }

}
