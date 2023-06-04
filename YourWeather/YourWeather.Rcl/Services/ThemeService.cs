using Microsoft.JSInterop;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public abstract class ThemeService : IThemeService
    {
        public ThemeService(IJSRuntime jSRuntime)
        {
            JS = jSRuntime;
            AddListent();
        }

        protected IJSRuntime JS;
        protected IJSObjectReference? module;
        protected ThemeType _themeType = ThemeType.Light;

        public virtual Dictionary<string, ThemeType> ThemeTypes { get; } = new()
        {
            {"跟随系统",ThemeType.System },
            {"浅色",ThemeType.Light },
            {"深色",ThemeType.Dark }
        };

        public event Action<ThemeType>? OnChanged;
        event Action<ThemeType>? SystemThemeChanged;

        [JSInvokable]
        public void SystemThemeChange(bool value)
        {
            ThemeType themeType = value ? ThemeType.Dark : ThemeType.Light;
            SystemThemeChanged?.Invoke(themeType);
        }

        protected async Task InitModule()
        {
            module ??= await JS.InvokeAsync<IJSObjectReference>("import", "./_content/YourWeather.Rcl/js/system-theme.js");
        }

        private async void AddListent()
        {
            await InitModule();
            var dotNetCallbackRef = DotNetObjectReference.Create(this);
            await module!.InvokeVoidAsync("followSystemTheme", new object[2] { dotNetCallbackRef, "SystemThemeChange" });
        }

        public virtual async Task SetThemeType(ThemeType value)
        {
            if (_themeType == value)
            {
                return;
            }

            _themeType = value;
            if (value == ThemeType.System)
            {
                SystemThemeChanged += NotifyStateChanged;
            }
            else
            {
                SystemThemeChanged -= NotifyStateChanged;
            }
            ThemeType themeType = await GetThemeType();
            NotifyStateChanged(themeType);
        }

        public virtual async Task<ThemeType> GetThemeType()
        {
            if (_themeType == ThemeType.System)
            {
                await InitModule();
                var dark = await module!.InvokeAsync<bool>("systemIsDarkTheme", new object[] { });
                return dark ? ThemeType.Dark : ThemeType.Light;
            }

            return _themeType;
        }

        protected virtual void NotifyStateChanged(ThemeType themeType)
        {
            OnChanged?.Invoke(themeType);
        }

    }
}
