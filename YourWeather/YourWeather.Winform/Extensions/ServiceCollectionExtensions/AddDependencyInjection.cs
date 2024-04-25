using Microsoft.Extensions.DependencyInjection;
using YourWeather.Rcl.Services;

namespace YourWeather.Winform.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISettingsService, Rcl.Desktop.Services.SettingService>();
            services.AddScoped<IThemeService, Rcl.Services.ThemeService>();
            services.AddSingleton<IWeatherService, Rcl.Services.WeatherService>();
            services.AddScoped<IPlatformIntegration, Rcl.Services.PlatformIntegration>();
            services.AddSingleton<IStaticWebAssets, Rcl.Desktop.Services.StaticWebAssets>();
            services.AddScoped<ILocationService, Rcl.Services.LocationService>();
            return services;
        }
    }
}
