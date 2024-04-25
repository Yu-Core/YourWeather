using Microsoft.Extensions.DependencyInjection;
using YourWeather.Rcl.Services;

namespace YourWeather.Photino.Extensions
{
    public static partial class ServiceCollectionExtend
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISettingsService, Services.SettingService>();
            services.AddScoped<IThemeService, ThemeService>();
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddScoped<IPlatformIntegration, PlatformIntegration>();
            services.AddSingleton<IStaticWebAssets, Services.StaticWebAssets>();
            services.AddScoped<ILocationService, Rcl.Services.LocationService>();
            return services;
        }
    }
}
