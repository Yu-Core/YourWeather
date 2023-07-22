using System.Text.Json;

namespace YourWeather.Server.Services
{
    public class PlatformService : Rcl.Services.PlatformService
    {
        public override async Task<T> ReadJsonAsync<T>(string baseUri)
        {
#if DEBUG
            var uri = $"{AppContext.BaseDirectory}/wwwroot/{baseUri}";
#else
            var uri = $"{AppContext.BaseDirectory}/wwwroot/_content/YourWeather.Rcl/{baseUri}";
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
