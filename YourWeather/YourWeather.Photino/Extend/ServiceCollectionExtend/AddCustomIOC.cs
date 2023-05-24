using YourWeather.Shared;
using Microsoft.Extensions.DependencyInjection;
using YourWeather.Phoptino.Services;

namespace YourWeather.Phoptino.Extend
{
    public static partial class ServiceCollectionExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<ISettingsService, SettingService>();
            services.AddSingleton<IThemeService, ThemeService>();
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddSingleton<ISystemService, SystemService>();
            return services;
        }
    }
}
