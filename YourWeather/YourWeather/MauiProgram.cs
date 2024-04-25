using CommunityToolkit.Maui;
using Darnton.Blazor.DeviceInterop.Geolocation;
using MauiBlazorToolkit.Extensions;
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
                .UseMauiBlazorToolkit(options =>
                {
                    options.TitleBar = true;
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseVersionTracking();
                }); ;

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddMasaBlazor();
            builder.Services.AddScoped<IGeolocationService, GeolocationService>();
            builder.Services.AddCustomIOC();
            builder.Services.AddMauiExceptionHandle();

            return builder.Build();
        }
    }
}