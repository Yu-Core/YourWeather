using BlazorToolkit.Essentials;
using System.Reflection;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public abstract class PlatformService : IPlatformService
    {
        public virtual string GetVersion()
        {
            var assembly = Assembly.GetEntryAssembly();
            if(assembly == null)
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

        public virtual Task OpenBrowserUrl(string url)
        {
            return Browser.Default.OpenAsync(url);
        }
    }
}
