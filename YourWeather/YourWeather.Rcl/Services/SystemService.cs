using Microsoft.JSInterop;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public class SystemService : ISystemService ,IAsyncDisposable
    {
        private readonly IJSRuntime JS;
        private IJSObjectReference module = default!;
        public SystemService(IJSRuntime js)
        {
            JS = js;

        }

        public async Task OpenBrowserUrl(string url)
        {
            //不要用window.open方法，新窗口没有加载完，回到原来窗口，会卡死
            //JS.InvokeVoidAsync("open", url, "_blank");

            await InitModule();
            await module.InvokeVoidAsync("openBrowserUrl", url, url);
        }

        public async Task InitModule()
        {
            if (module != null)
            {
                return;
            }

            module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/YourWeather.Rcl/js/system-service.js");
        }

        public async ValueTask DisposeAsync()
        {
            if(module != null)
            {
                await module.DisposeAsync();
            }
            GC.SuppressFinalize(this);
        }
    }
}
