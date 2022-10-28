using YourWeather.IService;
using YourWeather.Model.Enum;

namespace YourWeather.BlazorWasm.Service
{
    public class SystemThemeService : ISystemThemeService
    {
        public bool IsDark(ThemeState themeState)
        {

            if (themeState == ThemeState.Dark)
            {
                return true;
            }

            return false;
        }
        public void ClearSystemThemeHandler()
        {
            Onchange.Invoke();
        }

        public event Action Onchange;

        
        /// <summary>
        /// 系统主题切换
        /// </summary>
        public void AddSystemThemeHandler()
        {
            Onchange.Invoke();
        }
        

    }
}
