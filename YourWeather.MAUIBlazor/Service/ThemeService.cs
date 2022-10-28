using BlazorComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model.Enum;

namespace YourWeather.MAUIBlazor.Service
{
    public class ThemeService : IThemeService
    {
        
        public bool IsDark(ThemeState themeState)
        {
            if(themeState == ThemeState.System)
            {
                return Application.Current!.RequestedTheme == AppTheme.Dark;
            }
            else
            {
                if(themeState == ThemeState.Dark)
                {
                    return true;
                }
            }

            return false;
        }
        
        public event Action Onchange;

        /// <summary>
        /// 获取当前系统主题
        /// </summary>
        /// <returns></returns>
        

        private void HandlerAppThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            Onchange.Invoke();
        }
        /// <summary>
        /// 系统主题切换
        /// </summary>
        public void ThemeChanged(ThemeState themeState)
        {
            if(themeState == ThemeState.System)
            {
                Application.Current!.RequestedThemeChanged += HandlerAppThemeChanged;
            }
            else
            {
                Application.Current!.RequestedThemeChanged -= HandlerAppThemeChanged;
            }
            Onchange.Invoke();
        }
    }
}
