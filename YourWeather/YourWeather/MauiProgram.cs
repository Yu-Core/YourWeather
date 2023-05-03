using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using YourWeather.Extend;
using YourWeather.Shared;

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
            builder.Services.AddMasaBlazor().AddI18nForMauiBlazor("wwwroot/_content/YourWeather.Rcl/i18n");
            builder.Services.AddCustomIOC();

            return builder.Build();
        }
    }
}