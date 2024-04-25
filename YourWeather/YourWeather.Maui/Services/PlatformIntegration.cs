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
    }
}
