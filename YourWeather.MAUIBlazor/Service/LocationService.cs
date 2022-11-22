using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model.Location;
using YourWeather.Model.Result;

namespace YourWeather.MAUIBlazor.Service
{
    public class LocationService : ILocationService
    {
        private IJSRuntime JS { get; set; }
        public LocationData? SelectedLocation { get; set; }
        public List<LocationData>? ChinaCities { get; set; }

        public LocationService(IJSRuntime jS)
        {
            JS = jS;
            InitChinaCities();
        }
        private LocationData? CurrentLocation;

        public event Action<Result<LocationData>>? OnLocationChanged;

        public async void InitCurrentLocation()
        {
            if (CurrentLocation == null)
            {
                DotNetObjectReference<LocationService> callbackObj = DotNetObjectReference.Create(this);
                await JS.InvokeAsync<int>("watchPosition", new object[2] { callbackObj, "OnPositionUpdated" });

            }
        }


        [JSInvokable]
        public void OnPositionUpdated(GeolocationResult result)
        {
            Result<LocationData> location = null;
            if (result.IsSuccess)
            {
                CurrentLocation = new LocationData()
                {
                    Lat = result.Position.Coords.Latitude,
                    Lon = result.Position.Coords.Longitude,
                };
                SelectedLocation = CurrentLocation;
                location = ResultHelper.Success(CurrentLocation);
            }
            else
            {
                location = ResultHelper.Error<LocationData>(result.Error.Code.ToString());
            }

            OnLocationChanged?.Invoke(location);
        }

        private async void InitChinaCities()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("location.json");
            using var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            ChinaCities = JsonSerializer.Deserialize<List<LocationData>>(contents);
        }
    }
}
