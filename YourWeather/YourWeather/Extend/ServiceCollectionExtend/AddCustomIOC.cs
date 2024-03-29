﻿using YourWeather.Services;
using YourWeather.Shared;

namespace YourWeather.Extend
{
    public static partial class ServiceCollectionExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddSingleton<ISettingsService, SettingService>();
            services.AddScoped<IThemeService, ThemeService>();
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddSingleton<IPlatformService, PlatformService>();
            services.AddScoped<ILocationService, Rcl.Services.LocationService>();
            return services;
        }
    }
}
