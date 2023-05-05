using Microsoft.JSInterop;
using System.Diagnostics;
using YourWeather.Shared;

namespace YourWeather.Winform.Services
{
    public class SystemService : ISystemService
    {
        public Task OpenBrowserUrl(string url)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            return Task.CompletedTask;
        }
    }
}
