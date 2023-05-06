using Microsoft.AspNetCore.Components.Web;
using YourWeather.Rcl.Components;
using YourWeather.Shared;

namespace YourWeather.Rcl.Pages
{
    public partial class WeatherSourcePage : PageComponentBase
    {
        private string? Key;
        private bool ShowEditDialog;
        private WeatherSourceType WeatherSourceType;
        private Dictionary<WeatherSourceType, IWeatherSource> WeatherSources => WeatherService.WeatherSources;

        private async Task OpenEditDialog(WeatherSourceType type)
        {
            WeatherSourceType = type;
            Key = await SettingsService.Get(type.ToString(), "");
            ShowEditDialog = true;
        }

        private async Task HandleOnEdit()
        {
            ShowEditDialog = false;
            await SettingsService.Save(WeatherSourceType.ToString(), Key);
        }

        private async Task HandleOnEnter(KeyboardEventArgs args)
        {
            if (!ShowEditDialog)
            {
                return;
            }

            if (args.Key == "Enter")
            {
                await HandleOnEdit();
            }
        }
    }
}
