using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.MAUIBlazor.Service;

namespace YourWeather.MAUIBlazor.Extend
{
    public static class IOCExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<IThemeService,ThemeService>();
            services.AddScoped<IProjectService,ProjectService>();
            services.AddScoped<IBrowserService,BrowserService>();
            return services;
        }
    }
}
