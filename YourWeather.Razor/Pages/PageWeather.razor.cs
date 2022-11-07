using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Model.Enum;
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
                return WeatherData.ForecastHours ?? new List<WeatherForecastHours>();
            }
        }
        private List<WeatherForecastDay> WeatherForecastDays
        {
            get
            {
                return WeatherData.ForecastDays ?? new List<WeatherForecastDay>();
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

        protected override void OnInitialized()
        {
            if (OperatingSystem.IsBrowser())
            {
                SettingsService.OnChange += InitWeather;
            }
            else
            {
                InitWeather();
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JS.InvokeVoidAsync("initSwiperForecastHours", null);
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private async void InitWeather()
        {
            WeatherData = await SelectWeatherSourceItem.WeatherData(42.296082, 121.903438);
            await InvokeAsync(StateHasChanged);
        }
    }
}
