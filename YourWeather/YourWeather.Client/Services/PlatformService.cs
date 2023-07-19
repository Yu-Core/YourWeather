using System.Net.Http.Json;

namespace YourWeather.Client.Services
{
    public class PlatformService : Rcl.Web.Services.PlatformService
    {
        private HttpClient HttpClient { get; set; }

        public PlatformService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public override async Task<T> ReadJsonAsync<T>(string baseUri)
        {
            string uri = $"_content/YourWeather.Rcl/{baseUri}";
            var result = await HttpClient.GetFromJsonAsync<T>(uri);
            return result ?? throw new Exception("not find json");
        }
    }
}
