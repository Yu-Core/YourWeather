using Darnton.Blazor.DeviceInterop.Geolocation;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public class LocationService : ILocationService
    {
        readonly IGeolocationService GeolocationService;
        public LocationService(IGeolocationService geolocationService) 
        {
            GeolocationService = geolocationService;
        }
        public async Task<Location> GetCurrentLocation()
        {
            var result = await GeolocationService.GetCurrentPosition();
            if(!result.IsSuccess)
            {
                return null;
            }
            else
            {
                return new Location()
                {
                    Lat = result.Position.Coords.Latitude,
                    Lon = result.Position.Coords.Longitude,
                };
            }
        }
    }
}
