﻿namespace YourWeather.Winform.Services
{
    public class ThemeService : Rcl.Services.ThemeService
    {
        protected override void NotifyStateChanged()
        {
            base.NotifyStateChanged();
            TitleBar.EnableDarkMode(Dark);
        }
    }
}
