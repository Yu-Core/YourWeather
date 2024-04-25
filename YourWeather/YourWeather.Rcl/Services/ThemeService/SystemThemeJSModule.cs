using Microsoft.JSInterop;
using YourWeather.Rcl.Services;
using YourWeather.Shared;

namespace SwashbucklerDiary.WebAssembly.Essentials
{
    public class SystemThemeJSModule : BlazorComponent.JSInterop.JSModule
    {
        public ThemeType SystemTheme { get; set; }

        public event Func<ThemeType, Task>? SystemThemeChanged;

        public SystemThemeJSModule(IJSRuntime js) : base(js, $"./_content/{StaticWebAssets.RclAssemblyName}/js/systemTheme.js")
        {
        }

        public async Task InitializedAsync()
        {
            var dotNetObject = DotNetObjectReference.Create(this);
            bool dark = await InvokeAsync<bool>("registerForSystemThemeChanged", [dotNetObject, nameof(OnSystemThemeChanged)]);
            SystemTheme = dark ? ThemeType.Dark : ThemeType.Light;
        }

        [JSInvokable]
        public Task OnSystemThemeChanged(bool isDarkTheme)
        {
            SystemTheme = isDarkTheme ? ThemeType.Dark : ThemeType.Light;
            return SystemThemeChanged?.Invoke(SystemTheme) ?? Task.CompletedTask;
        }
    }
}
