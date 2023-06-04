using Microsoft.JSInterop;

namespace YourWeather.Rcl.Web.Services
{
    public class ThemeService : Rcl.Services.ThemeService
    {
        public ThemeService(IJSRuntime jSRuntime) : base(jSRuntime)
        {
        }
    }
}
