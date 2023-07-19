using Microsoft.Extensions.DependencyInjection;
using YourWeather.Rcl.Desktop.Services;
using YourWeather.Shared;

namespace YourWeather.Winform.Extend
{
    public static partial class ServiceCollectionExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<ISettingsService, SettingService>();
            services.AddScoped<IThemeService, ThemeService>();
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddSingleton<IPlatformService, PlatformService>();
            services.AddScoped<ILocationService, Rcl.Services.LocationService>();
            return services;
        }
    }
}
