using Microsoft.Extensions.DependencyInjection;
using YourWeather.Rcl.Services;

namespace YourWeather.Photino.Extensions
{
    public static partial class ServiceCollectionExtend
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISettingsService, Services.SettingService>();
            services.AddScoped<IThemeService, Services.ThemeService>();
            services.AddSingleton<IWeatherService, Services.WeatherService>();
            services.AddSingleton<IPlatformIntegration, Services.PlatformIntegration>();
            services.AddScoped<ILocationService, Rcl.Services.LocationService>();
            return services;
        }
    }
}
