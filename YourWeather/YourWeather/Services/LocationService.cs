using Darnton.Blazor.DeviceInterop.Geolocation;
using System.Text.Json;

namespace YourWeather.Services
{
    public class LocationService : Rcl.Services.LocationService
    {
        public LocationService(IGeolocationService geolocationService) : base(geolocationService)
        {

        }

        protected override async Task<List<Shared.Location>> ReadDate()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("wwwroot/_content/YourWeather.Rcl/json/location.json");
            using var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            return JsonSerializer.Deserialize<List<Shared.Location>>(contents);
        }
    }
}
