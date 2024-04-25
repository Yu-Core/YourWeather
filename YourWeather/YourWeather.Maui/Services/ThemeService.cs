using CommunityToolkit.Maui.Core;
using MauiBlazorToolkit;
using MauiBlazorToolkit.Platform;
using YourWeather.Shared;
using Microsoft.Maui.ApplicationModel;

namespace YourWeather.Maui.Services
{
    public class ThemeService : Rcl.Services.ThemeService
    {
        public override Task<ThemeType> GetThemeType()
        {
            if (_themeType == ThemeType.System)
            {
                var themeType = Application.Current!.RequestedTheme == AppTheme.Dark ? ThemeType.Dark : ThemeType.Light;
                return Task.FromResult(themeType);
            }

            return Task.FromResult(_themeType ?? ThemeType.Light);
        }

        public override async Task SetThemeType(ThemeType value)
        {
            if (_themeType == value)
            {
                return;
            }

            _themeType = value;
            if (value == ThemeType.System)
            {
                Application.Current.RequestedThemeChanged += NotifyStateChanged;
            }
            else
            {
                Application.Current.RequestedThemeChanged -= NotifyStateChanged;
            }

            ThemeType themeType = await GetThemeType();
            InternalNotifyStateChanged(themeType);
        }

        private void NotifyStateChanged(object sender, AppThemeChangedEventArgs e)
        {
            InternalNotifyStateChanged(e.RequestedTheme == AppTheme.Dark ? ThemeType.Dark : ThemeType.Light);
        }

        protected override void InternalNotifyStateChanged(ThemeType themeType)
        {
            base.InternalNotifyStateChanged(themeType);
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
