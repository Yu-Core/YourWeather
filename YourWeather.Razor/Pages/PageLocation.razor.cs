using BlazorComponent;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Model.Location;
using YourWeather.Service;

namespace YourWeather.Razor.Pages
{
    public partial class PageLocation
    {
        #region 注入

        [Inject]
        private IThemeService? ThemeService { get; set; }
        [Inject]
        private ISettingsService SettingsService { get; set; }
        [Inject]
        private ILocationService LocationService { get; set; }
        [Inject]
        private BackPressService BackPressService { get; set; }

        #endregion

        #region 变量

        private Settings SettingsData => SettingsService.Settings;
        private bool ShowDialogSearchCity
        {
            get => BackPressService.DialogsState[8];
            set
            {
                BackPressService.DialogsState[8] = value;
            }
        }
        private bool ShowDeleteDialog
        {
            get => BackPressService.DialogsState[9];
            set
            {
                BackPressService.DialogsState[9] = value;
                if (!value)
                {
                    CloseDeleteDialog();
                }
            }
        }

        private Action? OnDeleteLocationData;
        private string DeleteDialogText;
        private LocationData? SelectedCity
        {
            get => SettingsData.City;
            set
            {
                SettingsData.City = value;
            }
        }

        #endregion

        #region 方法

        private bool IsDark() => ThemeService.IsDark(SettingsData.ThemeState);


        protected override Task OnInitializedAsync()
        {
            ThemeService.Onchange += StateHasChanged;
            BackPressService.OnBackPressChanged += StateHasChanged;
            LocationService.OnInitVoid += StateHasChanged;
            return base.OnInitializedAsync();
        }
        private void OpenDeleteDialog(string Name, LocationData locationData)
        {
            DeleteDialogText = Name;
            OnDeleteLocationData += () => { ShowDeleteDialog = false; SettingsData.RemoveLocationData(locationData); };
            ShowDeleteDialog = true;
            StateHasChanged();
        }
        private void CloseDeleteDialog()
        {
            DeleteDialogText = string.Empty;
            foreach (var item in OnDeleteLocationData.GetInvocationList())
            {
                OnDeleteLocationData -= (Action)item;
            }
        }

        private void SelectedCityChanged(bool value,LocationData? locationData)
        {
            if(value)
            {
                SelectedCity = locationData;
                LocationService.NotifyCityChanged();
            }
            StateHasChanged();
            
        }
        

        private bool GetSwitchCityValue(LocationData? locationData)
        {
            if(locationData != null && SelectedCity != null)
            {
                return SelectedCity.Info == locationData.Info;
            }
            else if(locationData == null && SelectedCity == null)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
