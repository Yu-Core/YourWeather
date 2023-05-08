using YourWeather.Shared;

namespace YourWeather.Services
{
    public class SystemService : ISystemService
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
