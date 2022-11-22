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
using YourWeather.Service;

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
        [Inject]
        private BackPressService BackPressService { get; set; }

        private Settings SettingsData => SettingsService.Settings;
        private bool IsDark() => ThemeService.IsDark(SettingsData.ThemeState);
        private bool ShowDialogSearchCity
        {
            get => BackPressService.DialogsState[8];
            set
            {
                BackPressService.DialogsState[8] = value;
            }
        }
        private bool ShowDeleteButton
        {
            get => BackPressService.DialogsState[9];
            set
            {
                BackPressService.DialogsState[9] = value;
            }
        }

        protected override Task OnInitializedAsync()
        {
            ThemeService.Onchange += StateHasChanged;
            BackPressService.OnBackPressChanged += StateHasChanged;
            LocationService.OnLocationChanged += (Result<LocationData> result) => { StateHasChanged(); };
            return base.OnInitializedAsync();
        }
        private void DeleteLocationData(LocationData locationData)
        {
            SettingsData.RemoveLocationData(locationData);
            ShowDeleteButton = false;
        }
    }
}
