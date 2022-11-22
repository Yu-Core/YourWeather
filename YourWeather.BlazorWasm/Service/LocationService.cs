using Darnton.Blazor.DeviceInterop.Geolocation;
using System.Net.Http.Json;
using YourWeather.IService;
using YourWeather.Model.Location;
using YourWeather.Model.Result;

namespace YourWeather.BlazorWasm.Service
{
    public class LocationService : ILocationService
    {
        private IGeolocationService GeolocationService { get; set; }
        private HttpClient HttpClient { get; set; }
        public LocationData? SelectedLocation { get; set; }
        public List<LocationData>? ChinaCities { get; set; }

        public LocationService(IGeolocationService geolocationService, HttpClient httpClient)
        {
            GeolocationService = geolocationService;
            HttpClient = httpClient;
            InitChinaCities();
        }
        private LocationData? CurrentLocation;

        public event Action<Result<LocationData>>? OnLocationChanged;

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
                        Lat = currentPositionResult.Position.Coords.Latitude,
                        Lon = currentPositionResult.Position.Coords.Longitude,
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

            OnLocationChanged?.Invoke(location);
        }

        private async void InitChinaCities()
        {
            ChinaCities = await HttpClient.GetFromJsonAsync<List<LocationData>>("location/location.json");
        }
    }
}
