using YourWeather.IService;

namespace YourWeather.BlazorWasm.Service
{
    public class ThemeService : IThemeService
    {
        public bool IsMAUI {get;set;} = false;

        public event Action? Onchange;

        public bool IsDark()
        {
            throw new NotImplementedException();
        }

        public void ThemeChanged()
        {
            throw new NotImplementedException();
        }
    }
}
