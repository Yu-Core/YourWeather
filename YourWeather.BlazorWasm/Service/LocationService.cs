using Darnton.Blazor.DeviceInterop.Geolocation;
using YourWeather.IService;
using YourWeather.Model.Location;
using YourWeather.Model.Result;

namespace YourWeather.BlazorWasm.Service
{
    public class LocationService : ILocationService
    {
        public IGeolocationService GeolocationService { get; set; }
        public LocationService(IGeolocationService geolocationService)
        {
            GeolocationService = geolocationService;
        }
        private LocationData _locationData;
        public async Task<Result<LocationData>> GetLocation()
        {
            if(_locationData == null)
            {
                var currentPositionResult = await GeolocationService.GetCurrentPosition();

                if (currentPositionResult.IsSuccess)
                {
                    _locationData = new LocationData()
                    {
                        Latitude = currentPositionResult.Position.Coords.Latitude,
                        Longitude = currentPositionResult.Position.Coords.Longitude,
                    };
                }
                else
                {
                    return ResultHelper.Error<LocationData>(currentPositionResult.Error.Code.ToString());
                }
            }

            return ResultHelper.Success(_locationData);
        }
    }
}
