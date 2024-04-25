using YourWeather.Rcl.Services;

namespace YourWeather.Maui.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<ISettingsService, Services.SettingService>();
            services.AddScoped<IThemeService, Services.ThemeService>();
            services.AddSingleton<IWeatherService, Services.WeatherService>();
            services.AddSingleton<IPlatformIntegration, Services.PlatformIntegration>();
            services.AddSingleton<IStaticWebAssets, Services.StaticWebAssets>();
            services.AddScoped<ILocationService, LocationService>();
            return services;
        }
    }
}
