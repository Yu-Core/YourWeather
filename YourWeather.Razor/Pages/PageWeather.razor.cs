using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Model.Weather;
using YourWeather.Model.Weather.WeatherSource;
using YourWeather.Service;

namespace YourWeather.Razor.Pages
{
    public partial class PageWeather
    {
        [Inject]
        private ISettingsService? SettingsService { get; set; }
        private string Temp { get; set; }
        private List<WeatherForecastDay> ForecastDays { get; set; } = new List<WeatherForecastDay>();
        private Settings SettinsData => SettingsService.Settings;

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
            SettingsService.OnChange += InitWeather;
        }

        private async void InitWeather()
        {
            var weatherLives = await SelectWeatherSourceItem.Lives(42.296082, 121.903438);
            Temp = weatherLives.Temp;
            ForecastDays = await SelectWeatherSourceItem.ForecastDay(42.296082, 121.903438);
            await InvokeAsync(StateHasChanged);
        }
    }
}
