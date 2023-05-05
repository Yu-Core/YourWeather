using Microsoft.JSInterop;

namespace YourWeather.Server.Services
{
    public class SystemService : Rcl.Services.SystemService
    {
        public SystemService(IJSRuntime js) : base(js)
        {
        }
    }
}
