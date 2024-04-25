using System.Text.Json;
using YourWeather.Rcl.Services;

namespace YourWeather.Maui.Services
{
    public class PlatformIntegration : IPlatformIntegration
    {
        public string GetVersion()
        {
            return VersionTracking.Default.CurrentVersion.ToString();
        }

        public Task OpenBrowserUrl(string url)
        {
            return Browser.Default.OpenAsync(url, BrowserLaunchMode.External);
        }

        public async Task<T> ReadJsonAsync<T>(string baseUri)
        {
            string uri = $"wwwroot/_content/YourWeather.Rcl/{baseUri}";
            bool exists = await FileSystem.AppPackageFileExistsAsync(uri).ConfigureAwait(false);
            if (!exists)
            {
                throw new Exception("not find json");
            }

            using var stream = await FileSystem.OpenAppPackageFileAsync(uri).ConfigureAwait(false);
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync().ConfigureAwait(false);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(contents, options) ?? throw new("not find json");
        }
    }
}
