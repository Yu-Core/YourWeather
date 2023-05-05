using Microsoft.JSInterop;

namespace YourWeather.Client.Services
{
    public class SystemService : Rcl.Services.SystemService
    {
        public SystemService(IJSRuntime js) : base(js)
        {
        }
    }
}
