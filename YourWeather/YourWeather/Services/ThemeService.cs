using CommunityToolkit.Maui.Core;
using MauiBlazorToolkit;
using MauiBlazorToolkit.Platform;
using Microsoft.JSInterop;
using YourWeather.Shared;

namespace YourWeather.Services
{
    public class ThemeService : Rcl.Services.ThemeService
    {
        public ThemeService(IJSRuntime jSRuntime) : base(jSRuntime)
        {
        }

        protected override void NotifyStateChanged(ThemeType themeType)
        {
            base.NotifyStateChanged(themeType);
            SetStatusBar(themeType);
        }

        private static readonly Color statusBarColorLight = Color.FromRgb(255, 255, 255);
        private static readonly Color statusBarColorDark = Color.FromRgb(18, 18, 18);

#pragma warning disable CA1416
        private static void SetStatusBar(ThemeType themeState)
        {
            var Dark = themeState == ThemeType.Dark;
            Color backgroundColor = Dark ? statusBarColorDark : statusBarColorLight;
#if WINDOWS || MACCATALYST
            TitleBar.SetColor(backgroundColor);
            TitleBarStyle titleBarStyle = Dark ? TitleBarStyle.LightContent : TitleBarStyle.DarkContent;
            TitleBar.SetStyle(titleBarStyle);
#elif ANDROID || IOS14_2_OR_GREATER
            CommunityToolkit.Maui.Core.Platform.StatusBar.SetColor(backgroundColor);
            StatusBarStyle statusBarStyle = Dark ? StatusBarStyle.LightContent : StatusBarStyle.DarkContent;
            CommunityToolkit.Maui.Core.Platform.StatusBar.SetStyle(statusBarStyle);
#endif
        }
    }
}
