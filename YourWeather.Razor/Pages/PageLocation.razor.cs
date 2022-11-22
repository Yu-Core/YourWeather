using BlazorComponent.I18n;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Model.Location;
using YourWeather.Model.Result;

namespace YourWeather.Razor.Pages
{
    public partial class PageLocation
    {
        [Inject]
        private IThemeService? ThemeService { get; set; }
        [Inject]
        private ISettingsService SettingsService { get; set; }
        [Inject]
        private ILocationService LocationService { get; set; }

        private Settings SettingsData => SettingsService.Settings;
        private bool IsDark() => ThemeService.IsDark(SettingsData.ThemeState);

        protected override Task OnInitializedAsync()
        {
            ThemeService.Onchange += StateHasChanged;
            LocationService.OnLocationChanged += (Result<LocationData> result) => { StateHasChanged(); };
            return base.OnInitializedAsync();
        }
    }
}
