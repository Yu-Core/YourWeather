using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;

namespace YourWeather.MAUIBlazor.Service
{
    public class SystemService : ISystemService
    {
        public void ExitApp()
        {
#if ANDROID
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#elif IOS
            Thread.CurrentThread.Abort();
#elif WINDOWS
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#else
            Environment.Exit(0);
#endif
        }

        public string GetAppVersion()
        {
            return AppInfo.Current.VersionString;
        }

        public async Task OpenLink(string Url)
        {
            try
            {
                await Browser.Default.OpenAsync(Url, BrowserLaunchMode.External);
            }
            catch (Exception ex)
            {
                throw;
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}
