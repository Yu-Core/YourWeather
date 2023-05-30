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
            string path = "wwwroot/json/location.json";
            if (!File.Exists(path))
            {
                path = "wwwroot/_content/YourWeather.Rcl/json/location.json";
            }

            var json = await File.ReadAllTextAsync(path);
            return JsonSerializer.Deserialize<List<Location>>(json) ?? throw new("not find location.json");
        }
    }
}
