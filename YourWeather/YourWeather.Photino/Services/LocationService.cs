using Darnton.Blazor.DeviceInterop.Geolocation;
using System.Text.Json;
using YourWeather.Shared;

namespace YourWeather.Photino.Services
{
    public class LocationService : Rcl.Services.LocationService
    {
        public LocationService(IGeolocationService geolocationService) : base(geolocationService)
        {

        }

        protected override async Task<List<Location>> ReadDate()
        {
            using var reader = new StreamReader("wwwroot/json/location.json");
            var contents = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<List<Location>>(contents) ?? throw new("not find location.json");
        }
    }
}
