using YourWeather.Winform.Services;
using YourWeather.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace YourWeather.Winform.Extend
{
    public static partial class ServiceCollectionExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<ISettingsService, SettingService>();
            services.AddScoped<IThemeService, ThemeService>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<ILocationService, LocationService>();
            return services;
        }
    }
}
