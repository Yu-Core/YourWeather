using Microsoft.Extensions.DependencyInjection;
using YourWeather.Rcl.Services;

namespace YourWeather.Wpf.Extend
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISettingsService, Rcl.Desktop.Services.SettingService>();
            services.AddScoped<IThemeService, Rcl.Desktop.Services.ThemeService>();
            services.AddSingleton<IWeatherService, Rcl.Desktop.Services.WeatherService>();
            services.AddSingleton<IPlatformIntegration, Rcl.Desktop.Services.PlatformIntegration>();
            services.AddSingleton<IStaticWebAssets, Rcl.Desktop.Services.StaticWebAssets>();
            services.AddScoped<ILocationService, Rcl.Services.LocationService>();
            return services;
        }
    }
}
