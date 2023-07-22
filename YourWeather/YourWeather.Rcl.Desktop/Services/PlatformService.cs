using System.Text.Json;

namespace YourWeather.Rcl.Desktop.Services
{
    public class PlatformService : Rcl.Services.PlatformService
    {

        public override string GetVersion()
        {
            return base.GetVersion();
        }

        public override async Task<T> ReadJsonAsync<T>(string baseUri)
        {
#if DEBUG
            string uri = $"wwwroot/{baseUri}";
#else
            string uri = $"wwwroot/_content/YourWeather.Rcl/{baseUri}";
#endif
            if (!File.Exists(uri))
            {
                throw new Exception("not find json");
            }

            var contents = await File.ReadAllTextAsync(uri).ConfigureAwait(false);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(contents, options) ?? throw new("not find json");
        }
    }
}
