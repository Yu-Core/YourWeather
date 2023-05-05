using System.Diagnostics;

namespace YourWeather.Rcl.Desktop.Services
{
    public class SystemService : Rcl.Services.SystemService
    {
        public override Task OpenBrowserUrl(string url)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            return Task.CompletedTask;
        }
    }
}
