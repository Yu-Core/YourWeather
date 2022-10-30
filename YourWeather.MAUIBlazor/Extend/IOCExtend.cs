using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.MAUIBlazor.Service;
using YourWeather.Service;

namespace YourWeather.MAUIBlazor.Extend
{
    public static class IOCExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<IThemeService, ThemeService>();
            services.AddSingleton<IProjectService, ProjectService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<WeatherService>();
            services.AddScoped<ISettingsService, SettingsService>();
            return services;
        }
    }
}
