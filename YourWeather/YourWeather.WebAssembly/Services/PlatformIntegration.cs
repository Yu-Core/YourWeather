using System.Net.Http.Json;

namespace YourWeather.WebAssembly.Services
{
    public class PlatformIntegration : Rcl.Web.Services.PlatformIntegration
    {
        private HttpClient HttpClient { get; set; }

        public PlatformIntegration(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public override async Task<T> ReadJsonAsync<T>(string baseUri)
        {
            string uri = $"_content/YourWeather.Rcl/{baseUri}";
            var result = await HttpClient.GetFromJsonAsync<T>(uri).ConfigureAwait(false);
            return result ?? throw new Exception("not find json");
        }
    }
}
