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
    public class SystemThemeService : ISystemThemeService
    {
        
        public bool IsDark(ThemeState themeState)
        {
            if(themeState == ThemeState.System)
            {
                return GetAppTheme() == AppTheme.Dark;
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
        public void ClearSystemThemeHandler()
        {
            Application.Current!.RequestedThemeChanged -= HandlerAppThemeChanged;
            Onchange.Invoke();
        }

        public event Action Onchange;

        /// <summary>
        /// 获取当前系统主题
        /// </summary>
        /// <returns></returns>
        private static AppTheme GetAppTheme()
        {
            return Application.Current!.RequestedTheme;
        }

        /// <summary>
        /// 系统主题切换
        /// </summary>
        public void AddSystemThemeHandler()
        {
            Application.Current!.RequestedThemeChanged += HandlerAppThemeChanged;
            Onchange.Invoke();
        }
        private void HandlerAppThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            Onchange.Invoke();
        }

    }
}
