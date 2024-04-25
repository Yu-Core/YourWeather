using Microsoft.JSInterop;
using System.Reflection;

namespace YourWeather.Rcl.Services
{
    public class PlatformIntegration : IPlatformIntegration
    {
        private readonly Lazy<ValueTask<IJSObjectReference>> _module;

        public PlatformIntegration(IJSRuntime jSRuntime)
        {
            _module = new(() => jSRuntime.InvokeAsync<IJSObjectReference>("import", $"./_content/{StaticWebAssets.RclAssemblyName}/js/platformIntegration.js"));
        }

        public virtual string GetVersion()
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null)
            {
                return string.Empty;
            }

            var assemblyFileVersionAttribute = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            if (assemblyFileVersionAttribute == null)
            {
                return string.Empty;
            }

            return assemblyFileVersionAttribute.Version;
        }

        public virtual async Task OpenBrowserUrl(string url)
        {
            var module = await _module.Value;
            await module.InvokeVoidAsync("openBrowserUrl", url);
        }
    }
}
