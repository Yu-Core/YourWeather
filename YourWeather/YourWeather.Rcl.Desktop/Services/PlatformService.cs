using System.Diagnostics;

namespace YourWeather.Rcl.Desktop.Services
{
    public class PlatformService : Rcl.Services.PlatformService
    {
        public override Task OpenBrowserUrl(string url)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            return Task.CompletedTask;
        }

        public override string GetVersion()
        {
            return base.GetVersion();
        }
    }
}
