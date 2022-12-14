using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection;
using YourWeather.IService;

namespace YourWeather.BlazorWasm.Service
{
    public class SystemService : ISystemService
    {
        [Inject]
        IJSRuntime JS { get; set; }

        public SystemService(IJSRuntime jS)
        {
            JS = jS;
        }

        public async Task OpenLink(string Url)
        {
            await JS.InvokeAsync<object>("open", Url, "_blank");
        }

        public void ExitApp()
        {
            throw new NotImplementedException();
        }

        public string GetAppVersion()
        {
            return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
        }
    }
}
