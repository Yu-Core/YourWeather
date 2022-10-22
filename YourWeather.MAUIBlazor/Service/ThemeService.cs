using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;

namespace YourWeather.MAUIBlazor.Service
{
    public class ThemeService : IThemeService
    {
        public bool IsDark() => ThemeService.GetAppTheme() == AppTheme.Dark;

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
        public void ThemeChanged()
        {
            Application.Current!.RequestedThemeChanged += HandlerAppThemeChanged;
        }
        private void HandlerAppThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            Onchange?.Invoke();
        }

    }
}
