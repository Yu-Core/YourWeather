using YourWeather.Shared;
using Microsoft.Extensions.DependencyInjection;
using YourWeather.Photino.Services;

namespace YourWeather.Photino.Extend
{
    public static partial class ServiceCollectionExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<ISettingsService, SettingService>();
            services.AddScoped<IThemeService, ThemeService>();
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddSingleton<IPlatformService, PlatformService>();
            return services;
        }
    }
}
