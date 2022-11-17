using Darnton.Blazor.DeviceInterop.Geolocation;
using YourWeather.IService;
using YourWeather.Model.Location;
using YourWeather.Model.Result;

namespace YourWeather.BlazorWasm.Service
{
    public class LocationService : ILocationService
    {
        private IGeolocationService GeolocationService { get; set; }
        public LocationData SelectedLocation { get; set; }

        public LocationService(IGeolocationService geolocationService)
        {
            GeolocationService = geolocationService;
        }
        private LocationData CurrentLocation;

        public event Action<Result<LocationData>> OnLocationChanged;

        public async void InitCurrentLocation()
        {
            Result<LocationData> location = null;
            if(CurrentLocation == null)
            {
                var currentPositionResult = await GeolocationService.GetCurrentPosition();

                if (currentPositionResult.IsSuccess)
                {
                    CurrentLocation = new LocationData()
                    {
                        Latitude = currentPositionResult.Position.Coords.Latitude,
                        Longitude = currentPositionResult.Position.Coords.Longitude,
                    };
                    SelectedLocation = CurrentLocation;
                    location = ResultHelper.Success(CurrentLocation);
                }
                else
                {
                    location = ResultHelper.Error<LocationData>(currentPositionResult.Error.Code.ToString());
                }
            }
            else
            {
                location = ResultHelper.Success(CurrentLocation);
            }

            OnLocationChanged.Invoke(location);
        }

        
    }
}
