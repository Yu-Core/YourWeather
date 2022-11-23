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
        public List<LocationData>? ChinaCities { get; set; }

        public LocationService(IGeolocationService geolocationService, HttpClient httpClient)
        {
            GeolocationService = geolocationService;
            HttpClient = httpClient;
            InitChinaCities();
        }
        public LocationData? CurrentLocation { get; set; }

        public event Action<Result<LocationData>>? OnInit;
        public event Action? OnInitVoid;
        public event Action? OnCityChanged;

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

            OnInit?.Invoke(location);
            OnInitVoid?.Invoke();
        }

        private async void InitChinaCities()
        {
            ChinaCities = await HttpClient.GetFromJsonAsync<List<LocationData>>("location/location.json");
        }

        public void NotifyCityChanged()
        {
            OnCityChanged?.Invoke();
        }
    }
}
