using YourWeather.IService;
using YourWeather.Model.Enum;

namespace YourWeather.BlazorWasm.Service
{
    public class ThemeService : IThemeService
    {
        public bool IsDark(ThemeState themeState)
        {

            if (themeState == ThemeState.Dark)
            {
                return true;
            }

            return false;
        }

        public event Action Onchange;

        
        /// <summary>
        /// 系统主题切换
        /// </summary>
        public void ThemeChanged(ThemeState themeState)
        {
            Onchange.Invoke();
        }
    }
}
