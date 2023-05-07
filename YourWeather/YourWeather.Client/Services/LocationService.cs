using Darnton.Blazor.DeviceInterop.Geolocation;
using System.Net.Http.Json;
using YourWeather.Shared;

namespace YourWeather.Client.Services
{
    public class LocationService : Rcl.Web.Services.LocationService
    {
        private HttpClient HttpClient { get; set; }

        public LocationService(IGeolocationService geolocationService, HttpClient httpClient) : base(geolocationService)
        {
            HttpClient = httpClient;
        }

        protected override async Task<List<Location>> ReadDate()
        {
            var result = await HttpClient.GetFromJsonAsync<List<Location>>("_content/YourWeather.Rcl/json/location.json");
            return result ?? throw new Exception("not find location.json");
        }
    }
}
