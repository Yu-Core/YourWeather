using YourWeather.Shared;

namespace YourWeather.Services
{
    public class SystemService : ISystemService
    {
        public Task OpenBrowserUrl(string url)
        {
            return Browser.Default.OpenAsync(url, BrowserLaunchMode.External);
        }
    }
}
