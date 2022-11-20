using BlazorComponent;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Model.Enum;
using YourWeather.Model.Location;
using YourWeather.Model.Result;
using YourWeather.Model.Weather;
using YourWeather.Model.Weather.WeatherSource;
using YourWeather.Service;

namespace YourWeather.Razor.Pages
{
    public partial class PageWeather
    {
        [Inject]
        private ISettingsService? SettingsService { get; set; }
        [Inject]
        private IThemeService ThemeService { get; set; }
        [Inject]
        IJSRuntime JS { get; set; }
        [Inject]
        private WeatherService? WeatherService { get; set; }
        [Inject]
        private MasaBlazor MasaBlazor { get; set; }
        [Inject]
        private ILocationService LocationService { get; set; }
        [Inject]
        private ISystemService SystemService { get; set; }

        private string GetDayWeatherIcon(string weather) => WeatherService.GetWeatherIcon(weather);
        private string GetWeatherIcon(string weather, DateTime dateTime) => WeatherService.GetWeatherIcon(weather, dateTime);
        private bool LoadingUpadateWeather = false;
        private string ErrorDialogTitle = string.Empty;
        private string ErrorDialogText = string.Empty;
        private bool ShowErrorDialog = false;
        private LocationData SelectedLocation => LocationService.SelectedLocation;
        private WeatherData WeatherData { get; set; } = new WeatherData();
        private WeatherLives WeatherLives
        {
            get
            {
                return WeatherData.Lives ?? new WeatherLives();
            }
        }
        private List<WeatherForecastHours> WeatherForecastHours
        {
            get
            {
                return WeatherData.ForecastHours /*?? new List<WeatherForecastHours>()*/;
            }
        }
        private List<WeatherForecastDay> WeatherForecastDays
        {
            get
            {
                return WeatherData.ForecastDays /*?? new List<WeatherForecastDay>()*/;
            }
        }
        private Settings SettingsData => SettingsService.Settings;

        private bool IsDark()
        {
            return ThemeService.IsDark(SettingsData.ThemeState);
        }

        private int SelectWeatherSourceIndex
        {
            get => SettingsData.WeatherSource;
            set
            {
                SettingsData.WeatherSource = value;
            }
        }

        private IWeatherSource SelectWeatherSourceItem => WeatherSourceItems[SelectWeatherSourceIndex];


        private List<IWeatherSource> WeatherSourceItems => StaticDataService.WeatherSources;

        protected override Task OnInitializedAsync()
        {
            LocationService.OnLocationChanged += InitWeather;
            if (OperatingSystem.IsBrowser())
            {
                SettingsService.OnInit += LocationService.InitCurrentLocation;
            }
            else
            {
                LocationService.InitCurrentLocation();
            }

            WeatherService.OnSourceChanged += UpadateWeather;
            WeatherService.OnShowChanged += StateHasChanged;
            MasaBlazor.Breakpoint.OnUpdate += () => { return InvokeAsync(StateHasChanged); };

            return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                var objRef = DotNetObjectReference.Create(this);
                await JS.InvokeVoidAsync("initPulltorefresh", new object[2] { objRef,"UpadateWeather" });
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private async void InitWeather(Result<LocationData> result)
        {
            if (result.IsSuccess)
            {
                await GetWeatherData();
            }
            else
            {
                ErrorDialog("定位失败", result.Message);
            }
        }

        [JSInvokable]
        public async void UpadateWeather()
        {
            LoadingUpadateWeather = true;
            if (SelectedLocation != null)
            {
                await GetWeatherData();
            }

            LoadingUpadateWeather = false;
            await InvokeAsync(StateHasChanged);
        }

        private async Task GetWeatherData()
        {
            WeatherData = await SelectWeatherSourceItem.GetWeatherData(SelectedLocation.Latitude, SelectedLocation.Longitude);
            if (WeatherData.Lives != null)
            {
                await InvokeAsync(StateHasChanged);
                await JS.InvokeVoidAsync("updateSwiper", null);
                await JS.InvokeVoidAsync("initSwiperForecastHours", null);
            }
            else
            {
                ErrorDialog("天气加载失败", "请尝试更换天气源");
            }
        }

        private void ErrorDialog(string title, string text)
        {
            ErrorDialogTitle = title;
            ErrorDialogText = text;
            ShowErrorDialog = true;
            StateHasChanged();
        }
    }
}
