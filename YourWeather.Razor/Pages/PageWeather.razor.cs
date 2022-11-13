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
        private IPopupService PopupService { get; set; }

        private string GetWeatherIcon(string weather) => WeatherService.GetWeatherIcon(weather);
        private string GetWeatherIcon(string weather, DateTime dateTime) => WeatherService.GetWeatherIcon(weather, dateTime);
        private bool LoadingUpadateWeather = false;
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
        private Settings SettinsData => SettingsService.Settings;

        private bool IsDark()
        {
            return ThemeService.IsDark(SettinsData.ThemeState);
        }

        private int SelectWeatherSourceIndex
        {
            get => SettinsData.WeatherSource;
            set
            {
                SettinsData.WeatherSource = value;
            }
        }

        private IWeatherSource SelectWeatherSourceItem => WeatherSourceItems[SelectWeatherSourceIndex];


        private List<IWeatherSource> WeatherSourceItems => StaticDataService.WeatherSources;

        protected async override Task OnInitializedAsync()
        {
            if (OperatingSystem.IsBrowser())
            {
                SettingsService.OnChange += InitWeather;
            }
            else
            {
                InitWeather();
            }

            WeatherService.OnChange += InitWeather;
            MasaBlazor.Breakpoint.OnUpdate += () => { return InvokeAsync(StateHasChanged); };
        }


        private async void InitWeather()
        {
            var result = await LocationService.GetLocation();
            if (result.IsSuccess)
            {
                WeatherData = await SelectWeatherSourceItem.WeatherData(result.Data.Latitude, result.Data.Longitude);
                await InvokeAsync(StateHasChanged);
                await JS.InvokeVoidAsync("updateSwiper", null);
                await JS.InvokeVoidAsync("initSwiperForecastHours", null);
            }
            else
            {
                await PopupService.ConfirmAsync("定位失败", result.Message, AlertTypes.Error);
            }
        }
        private void UpadateWeather()
        {
            LoadingUpadateWeather = true;
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                InitWeather();
                LoadingUpadateWeather = false;
                await InvokeAsync(StateHasChanged);
            });
        }
    }
}
