using Masa.Blazor;
using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Model.Weather.WeatherSource;
using YourWeather.Service;

namespace YourWeather.Razor.Shared
{
    public partial class IndexContentManager
    {
        [Parameter]
        public bool Value { get; set; }
        [Parameter]
        public EventCallback<bool> ValueChanged { get; set; }
        [Inject]
        private ISettingsService? SettingsService { get; set; }
        [Inject]
        private IThemeService ThemeService { get; set; }
        [Inject]
        public WeatherService WeatherService { get; set; }
        [Inject] 
        public MasaBlazor MasaBlazor { get; set; }

        private Settings SettingsData => SettingsService.Settings;
        private bool IsDark => ThemeService.IsDark(SettingsData.ThemeState);
        private bool ShowLives
        {
            get => SettingsData.ShowLives;
            set
            {
                SettingsData.ShowLives = value;
                WeatherService.NotifyShowChanged();
            }
        }
        private bool ShowForeastHour
        {
            get => SettingsData.ShowForeastHour;
            set
            {
                SettingsData.ShowForeastHour = value;
                WeatherService.NotifyShowChanged();
            }
        }
        private bool ShowForeastDays
        {
            get => SettingsData.ShowForeastDays;
            set
            {
                SettingsData.ShowForeastDays = value;
                WeatherService.NotifyShowChanged();
            }
        }
        private bool ShowLivesInfo
        {
            get => SettingsData.ShowLivesInfo;
            set
            {
                SettingsData.ShowLivesInfo = value;
                WeatherService.NotifyShowChanged();
            }
        }

        protected virtual async Task HandleOnCancel(MouseEventArgs _)
        {
            await InternalValueChanged(false);
            
        }

        private async Task InternalValueChanged(bool value)
        {
            Value = value;

            if (ValueChanged.HasDelegate)
            {
                await ValueChanged.InvokeAsync(value);
            }
        }

    }
}
