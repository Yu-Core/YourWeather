using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;

namespace YourWeather.MAUIBlazor.Service
{
    public class BrowserService : IBrowserService
    {
        public async Task OpenLink(string Url)
        {
            try
            {
                await Browser.Default.OpenAsync(Url, BrowserLaunchMode.External);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}
