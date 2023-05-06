using Microsoft.Extensions.Logging;
using System.Text.Json;
using YourWeather.Rcl.Components;
using YourWeather.Shared;

namespace YourWeather.Rcl.Pages
{
    public partial class WeatherPage : PageComponentBase
    {
        private Location? Location;
        private WeatherSourceType WeatherSourceType;
        private WeatherData WeatherData = new();
        private string? Key;
        private bool ShowLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Title = "天气";
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await LoadSettings();
                await UpdateWeatherDate();
            }
        }

        private WeatherLives? Lives => WeatherData.Lives;
        private List<WeatherForecastHours>? ForecastHours => WeatherData.ForecastHours;
        private List<WeatherForecastDay>? ForecastDays => WeatherData.ForecastDays;

        private async Task LoadSettings()
        {
            var weatherSourceType = await SettingsService.Get<int>(SettingType.WeatherSource);
            WeatherSourceType = (WeatherSourceType)weatherSourceType;
            Key = await SettingsService.Get<string?>(WeatherSourceType.ToString(), null);
            var city = await SettingsService.Get<string>(SettingType.Location);
            if (!string.IsNullOrEmpty(city))
            {
                Location = JsonSerializer.Deserialize<Location>(city);
            }
            else
            {
                Location = await LocationService.GetCurrentLocation();
            }
        }

        private async Task UpdateWeatherDate()
        {
            await UpdateWeatherDate(WeatherSourceType, Location);
            ShowLoading = false;
            await InvokeAsync(StateHasChanged);
        }

        private async Task UpdateWeatherDate(WeatherSourceType weather, Location? location)
        {
            if (location != null)
            {
                var weatherData = await WeatherService.GetWeatherData(weather, location, Key);
                if (weatherData != null)
                {
                    WeatherData = weatherData;
                }
                else
                {
                    await PopupService.EnqueueSnackbarAsync(new()
                    {
                        Content = "天气数据请求失败，请尝试更换key，或更换天气源",
                        Type = BlazorComponent.AlertTypes.Error,
                    });
                }
            }

            await InvokeAsync(StateHasChanged);
        }

        private string GetDayWeatherIcon(string weather) => WeatherService.GetWeatherIcon(weather);
        private string GetWeatherIcon(string weather, DateTime dateTime) => WeatherService.GetWeatherIcon(weather, dateTime);
    }
}
