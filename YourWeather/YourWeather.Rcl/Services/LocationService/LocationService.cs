using Darnton.Blazor.DeviceInterop.Geolocation;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public class LocationService : ILocationService
    {
        private Location? CurrentLocation;
        private List<Location> AllLocations = new();
        private readonly IGeolocationService GeolocationService;
        private readonly IStaticWebAssets StaticWebAssets;

        public LocationService(IGeolocationService geolocationService, IStaticWebAssets staticWebAssets)
        {
            GeolocationService = geolocationService;
            StaticWebAssets = staticWebAssets;
        }

        public async Task<Location> GetCurrentLocation()
        {
            if (CurrentLocation != null)
            {
                return CurrentLocation;
            }

            var result = await GeolocationService.GetCurrentPosition();
            if (!result.IsSuccess)
            {
                return null;
            }
            else
            {
                CurrentLocation = new Location()
                {
                    Lat = result.Position.Coords.Latitude,
                    Lon = result.Position.Coords.Longitude,
                };
                return CurrentLocation;
            }
        }

        public async Task<List<Location>> GetAllLocations()
        {
            if (AllLocations == null || AllLocations.Count == 0)
            {
                AllLocations = await StaticWebAssets.ReadJsonAsync<List<Location>>("json/location.json");
            }

            return AllLocations;
        }
    }
}
