using CommunityToolkit.Maui;
using Darnton.Blazor.DeviceInterop.Geolocation;
using YourWeather.Extend;
using GeolocationService = YourWeather.Services.GeolocationService;

namespace YourWeather
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddMasaBlazor();
            builder.Services.AddScoped<IGeolocationService, GeolocationService>();
            builder.Services.AddCustomIOC();

            return builder.Build();
        }
    }
}