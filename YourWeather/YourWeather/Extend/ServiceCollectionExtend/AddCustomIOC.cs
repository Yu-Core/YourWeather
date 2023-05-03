using YourWeather.Services;
using YourWeather.Shared;

namespace YourWeather.Extend
{
    public static partial class ServiceCollectionExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddSingleton<ISettingsService, SettingService>();
            services.AddSingleton<IThemeService, ThemeService>();
            return services;
        }
    }
}
