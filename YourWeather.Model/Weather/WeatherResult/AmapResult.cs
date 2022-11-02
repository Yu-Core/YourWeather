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
        public string? Count { get; set; }
        public string? Info { get; set; }
        public string? Infocode { get; set; }
        public Life[]? Lives { get; set; }
    }

    
    public class Life
    {
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? Adcode { get; set; }
        public string? Weather { get; set; }
        public string? Temperature { get; set; }
        public string? Winddirection { get; set; }
        public string? Windpower { get; set; }
        public string? Humidity { get; set; }
        public string? Reporttime { get; set; }
    }

    
    public class AmapResultForecast
    {
        
        public string? Status { get; set; }
        public string? Count { get; set; }
        public string? Info { get; set; }
        public string? Infocode { get; set; }
        
        public Forecast[]? Forecasts { get; set; }
    }

    
    public class Forecast
    {
        public string? City { get; set; }
        public string? Adcode { get; set; }
        public string? Province { get; set; }
        public string? Reporttime { get; set; }
        public Cast[]? Casts { get; set; }
    }

    
    public class Cast
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
        
        public Regeocode? regeocode { get; set; }
        public string? info { get; set; }
        
        public string? infocode { get; set; }
    }

    
    public class Regeocode
    {
        public Addresscomponent? addressComponent { get; set; }
        public string? formatted_address { get; set; }
    }

    
    public class Addresscomponent
    {
        public object[]? city { get; set; }
        public string? province { get; set; }
        public string? adcode { get; set; }
        public string? district { get; set; }
        public string? towncode { get; set; }
        public Streetnumber? streetNumber { get; set; }
        public string? country { get; set; }
        public string? township { get; set; }
        public Businessarea[]? businessAreas { get; set; }
        public Building? building { get; set; }
        public Neighborhood? neighborhood { get; set; }
        public string? citycode { get; set; }
    }

    public class Streetnumber
    {
        public string? number { get; set; }
        public string? location { get; set; }
        public string? direction { get; set; }
        public string? distance { get; set; }
        public string? street { get; set; }
    }

    public class Building
    {
        public string? name { get; set; }
        public string? type { get; set; }
    }

    public class Neighborhood
    {
        public string? name { get; set; }
        public string? type { get; set; }
    }

    public class Businessarea
    {
        public string? location { get; set; }
        public string? name { get; set; }
        public string? id { get; set; }
    }

}
