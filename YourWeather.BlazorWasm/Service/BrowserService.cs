using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using YourWeather.IService;

namespace YourWeather.BlazorWasm.Service
{
    public class BrowserService : IBrowserService
    {
        [Inject]
        IJSRuntime JS { get; set; }

        public BrowserService(IJSRuntime jS)
        {
            JS = jS;
        }

        public async Task OpenLink(string Url)
        {
            await JS.InvokeAsync<object>("open", Url, "_blank");
        }
    }
}
