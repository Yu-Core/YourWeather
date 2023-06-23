using Microsoft.JSInterop;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public abstract class ThemeService : IThemeService
    {
        public event Action<ThemeType>? OnChanged;
        private readonly JSBinder _jsBinder;
        protected ThemeType _themeType = ThemeType.Light;
        protected event Action<ThemeType>? SystemThemeChanged;
        public virtual Dictionary<string, ThemeType> ThemeTypes { get; } = new()
        {
            {"跟随系统",ThemeType.System },
            {"浅色",ThemeType.Light },
            {"深色",ThemeType.Dark }
        };

        public ThemeService(IJSRuntime jSRuntime)
        {
            _jsBinder = new JSBinder(jSRuntime, "./_content/YourWeather.Rcl/js/system-theme.js");
        }

        [JSInvokable]
        public void SystemThemeChange(bool value)
        {
            ThemeType themeType = value ? ThemeType.Dark : ThemeType.Light;
            SystemThemeChanged?.Invoke(themeType);
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
                var module = await _jsBinder.GetModule();
                var dark = await module.InvokeAsync<bool>("systemIsDarkTheme", new object[] { });
                return dark ? ThemeType.Dark : ThemeType.Light;
            }

            return _themeType;
        }

        public async Task Init()
        {
            await AddListent();
        }

        protected virtual void NotifyStateChanged(ThemeType themeType)
        {
            OnChanged?.Invoke(themeType);
        }

        private async Task AddListent()
        {
            var dotNetCallbackRef = DotNetObjectReference.Create(this);
            var module = await _jsBinder.GetModule();
            await module.InvokeVoidAsync("followSystemTheme", new object[2] { dotNetCallbackRef, "SystemThemeChange" });
        }
    }

    internal class JSBinder
    {
        internal IJSRuntime JSRuntime;
        private readonly string _importPath;
        private Task<IJSObjectReference>? _module;

        public JSBinder(IJSRuntime jsRuntime, string importPath)
        {
            JSRuntime = jsRuntime;
            _importPath = importPath;
        }

        internal async Task<IJSObjectReference> GetModule()
        {
            return await (_module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", _importPath).AsTask());
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            if (_module != null)
            {
                var module = await _module;
                await module.DisposeAsync();
            }
        }
    }
}
