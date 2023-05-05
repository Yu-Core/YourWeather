using Darnton.Blazor.DeviceInterop.Geolocation;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public class LocationService : ILocationService
    {
        private Location? CurrentLocation;
        private readonly IGeolocationService GeolocationService;
        public LocationService(IGeolocationService geolocationService)
        {
            GeolocationService = geolocationService;
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
    }
}
