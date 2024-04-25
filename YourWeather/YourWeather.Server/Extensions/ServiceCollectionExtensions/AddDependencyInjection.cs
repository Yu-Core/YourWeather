using YourWeather.Rcl.Services;

namespace YourWeather.Server.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISettingsService, Rcl.Web.Services.SettingService>();
            services.AddScoped<IThemeService, Rcl.Services.ThemeService>();
            services.AddScoped<IWeatherService, Rcl.Services.WeatherService>();
            services.AddScoped<IPlatformIntegration, Rcl.Services.PlatformIntegration>();
            services.AddScoped<IStaticWebAssets, Services.StaticWebAssets>();
            services.AddScoped<ILocationService, Rcl.Services.LocationService>();
            return services;
        }
    }
}
