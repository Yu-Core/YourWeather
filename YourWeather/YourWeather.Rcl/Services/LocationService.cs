using Darnton.Blazor.DeviceInterop.Geolocation;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public class LocationService : ILocationService
    {
        private Location? CurrentLocation;
        private List<Location> AllLocations = new();
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

        public async Task<List<Location>> GetAllLocations()
        {
            if (AllLocations == null || AllLocations.Count == 0)
            {
                AllLocations = await ReadDate();
            }
            
            return AllLocations;
        }

        protected virtual Task<List<Location>> ReadDate()
        {
            throw new NotImplementedException();
        }
    }
}
