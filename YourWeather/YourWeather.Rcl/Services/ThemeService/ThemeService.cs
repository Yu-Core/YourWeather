﻿using Microsoft.JSInterop;
using SwashbucklerDiary.WebAssembly.Essentials;
using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public class ThemeService : IThemeService
    {
        private ThemeType? _theme;

        private readonly SystemThemeJSModule _systemThemeJSModule;

        public event Action<ThemeType>? OnChanged;

        public ThemeType RealTheme => _theme switch
        {
            ThemeType.System => _systemThemeJSModule.SystemTheme,
            ThemeType.Dark => ThemeType.Dark,
            _ => ThemeType.Light
        };

        public ThemeService(IJSRuntime jSRuntime)
        {
            _systemThemeJSModule = new SystemThemeJSModule(jSRuntime);
        }

        public Task InitializedAsync() => _systemThemeJSModule.InitializedAsync();

        public Task SetThemeAsync(ThemeType theme)
        {
            if (_theme == theme)
            {
                return Task.CompletedTask;
            }

            //跟随系统主题改变
            if (theme == ThemeType.System)
            {
                _systemThemeJSModule.SystemThemeChanged += HandleAppThemeChanged;
            }
            //取消跟随系统主题改变
            else if (_theme == ThemeType.System)
            {
                _systemThemeJSModule.SystemThemeChanged -= HandleAppThemeChanged;
            }

            _theme = theme;

            InternalNotifyStateChanged();
            return Task.CompletedTask;
        }

        private Task HandleAppThemeChanged(ThemeType theme)
        {
            InternalNotifyStateChanged();
            return Task.CompletedTask;
        }

        private void InternalNotifyStateChanged()
        {
            OnChanged?.Invoke(RealTheme);
        }
    }
}
