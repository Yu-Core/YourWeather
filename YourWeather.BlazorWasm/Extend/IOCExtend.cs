using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.BlazorWasm.Service;
using YourWeather.Service;

namespace YourWeather.BlazorWasm.Extend
{
    public static class IOCExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<IThemeService, ThemeService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<WeatherService>();
            services.AddScoped<ILocationService, LocationService>();
            return services;
        }
    }
}
