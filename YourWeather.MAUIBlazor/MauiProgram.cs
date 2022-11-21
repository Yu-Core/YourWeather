using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using YourWeather.MAUIBlazor.Extend;
using YourWeather.MAUIBlazor.Service;
using YourWeather.Razor;
using YourWeather.Razor.Shared;

namespace YourWeather.MAUIBlazor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddMasaBlazor();

            builder.Services.AddHotKeys();

            builder.Services.AddCustomIOC();

            return builder.Build();
        }
    }
}