
using YourWeather.Rcl.Web.Services;
using YourWeather.Shared;
using LocationService = YourWeather.Server.Services.LocationService;

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
            services.AddScoped<IPlatformService, PlatformService>();
            return services;
        }
    }
}
