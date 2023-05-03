using YourWeather.Client.Services;
using YourWeather.Shared;

namespace YourWeather.Client.Extend
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
