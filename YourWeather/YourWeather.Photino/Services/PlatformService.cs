using System.Text.Json;

namespace YourWeather.Photino.Services
{
    public class PlatformService : Rcl.Services.PlatformService
    {
        public override string GetVersion()
        {
            return base.GetVersion();
        }

        public override async Task<T> ReadJsonAsync<T>(string baseUri)
        {
            string uri = $"wwwroot/{baseUri}";
            if (!File.Exists(uri))
            {
                uri = $"wwwroot/_content/YourWeather.Rcl/{baseUri}";
            }

            var json = await File.ReadAllTextAsync(uri);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(json, options) ?? throw new("not find json");
        }
    }
}
