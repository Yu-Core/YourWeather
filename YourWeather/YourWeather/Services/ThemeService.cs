using CommunityToolkit.Maui.Core;
using YourWeather.Shared;

namespace YourWeather.Services
{
    public class ThemeService : Rcl.Services.ThemeService
    {
        private bool AlreadySet;
        public override Dictionary<string, ThemeType> ThemeTypes { get; } = new()
        {
            {"跟随系统",ThemeType.System },
            {"浅色",ThemeType.Light },
            {"深色",ThemeType.Dark }
        };

        protected override ThemeType GetThemeType()
        {
            if (_themeType == ThemeType.System)
            {
                return Application.Current!.RequestedTheme == AppTheme.Dark ? ThemeType.Dark : ThemeType.Light;
            }

            return _themeType;
        }

        protected override void SetThemeType(ThemeType value)
        {
            if (AlreadySet == false)
            {
                AlreadySet = true;
            }
            else
            {
                if (_themeType == value)
                {
                    return;
                }
            }

            _themeType = value;
            if (value == ThemeType.System)
            {
                Application.Current!.RequestedThemeChanged += HandlerAppThemeChanged;
            }
            else
            {
                Application.Current!.RequestedThemeChanged -= HandlerAppThemeChanged;
            }

            NotifyStateChanged();
        }

        private void HandlerAppThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            NotifyStateChanged();
        }

        protected override void NotifyStateChanged()
        {
            base.NotifyStateChanged();
            SetStatusBar(ThemeType);
        }

        private static readonly Color statusBarColorLight = Color.FromRgb(255, 255, 255);
        private static readonly Color statusBarColorDark = Color.FromRgb(18, 18, 18);
#pragma warning disable CA1416
        private void SetStatusBar(ThemeType themeState)
        {
            var Dark = themeState == ThemeType.Dark;
            Color backgroundColor = Dark ? statusBarColorDark : statusBarColorLight;
            Color foreColor = Dark ? Colors.White : Colors.Black;
#if WINDOWS
            WindowsTitleBar.SetColorForWindows(backgroundColor, foreColor);
#elif MACCATALYST
            MacTitleBar.SetTitleBarColorForMac(backgroundColor, foreColor);
#elif ANDROID || IOS14_2_OR_GREATER
            CommunityToolkit.Maui.Core.Platform.StatusBar.SetColor(backgroundColor);
            StatusBarStyle statusBarStyle = Dark ? StatusBarStyle.LightContent : StatusBarStyle.DarkContent;
            CommunityToolkit.Maui.Core.Platform.StatusBar.SetStyle(statusBarStyle);
#endif
        }
    }
}
