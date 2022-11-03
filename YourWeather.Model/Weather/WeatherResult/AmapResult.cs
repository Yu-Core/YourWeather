using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Weather.WeatherResult
{
    
    public class AmapResultLives
    {
        
        public string? Status { get; set; }
        public string? Infocode { get; set; }
        public AmapLife[]? Lives { get; set; }
    }

    
    public class AmapLife
    {
        public string? City { get; set; }
        public string? Adcode { get; set; }
        public string? Weather { get; set; }
        public string? Temperature { get; set; }
        public string? Winddirection { get; set; }
        public string? Windpower { get; set; }
        public string? Humidity { get; set; }
        public string? Reporttime { get; set; }
    }

    
    public class AmapResultForecastDay
    {
        
        public string? Status { get; set; }
        public string? Count { get; set; }
        public string? Info { get; set; }
        public string? Infocode { get; set; }
        
        public AmapForecast[]? Forecasts { get; set; }
    }

    
    public class AmapForecast
    {
        public string? City { get; set; }
        public string? Adcode { get; set; }
        public string? Province { get; set; }
        public string? Reporttime { get; set; }
        public AmapCast[]? Casts { get; set; }
    }

    
    public class AmapCast
    {
        public string? Date { get; set; }
        public string? Week { get; set; }
        public string? Dayweather { get; set; }
        public string? Nightweather { get; set; }
        public string? Daytemp { get; set; }
        public string? Nighttemp { get; set; }
        public string? Daywind { get; set; }
        public string? Nightwind { get; set; }
        public string? Daypower { get; set; }
        public string? Nightpower { get; set; }
    }

    
    public class AmapResultAdcode
    {
        
        public string? status { get; set; }
        
        public AmapRegeocode? regeocode { get; set; }
        
        public string? infocode { get; set; }
    }

    
    public class AmapRegeocode
    {
        public AmapAddresscomponent? addressComponent { get; set; }
    }

    
    public class AmapAddresscomponent
    {
        public string? adcode { get; set; }
    }

    

    

    

    

}
