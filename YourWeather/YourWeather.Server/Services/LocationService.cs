using Darnton.Blazor.DeviceInterop.Geolocation;
using System.Net.Http.Json;
using System.Text.Json;
using YourWeather.Shared;

namespace YourWeather.Server.Services
{
    public class LocationService : Rcl.Web.Services.LocationService
    {

        public LocationService(IGeolocationService geolocationService) : base(geolocationService)
        {

        }

        protected override async Task<List<Location>> ReadDate()
        {
            var path = $"{AppContext.BaseDirectory}/wwwroot/json/location.json";
            if(!File.Exists(path))
            {
                throw new Exception("not find location.json");
            }
            using var reader = new StreamReader(path);
            var contents = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<List<Location>>(contents) ?? throw new("not find location.json");
        }
    }
}
