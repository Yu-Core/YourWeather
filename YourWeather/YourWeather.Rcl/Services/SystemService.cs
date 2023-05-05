using Microsoft.JSInterop;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public class SystemService : ISystemService
    {
        public virtual Task OpenBrowserUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
