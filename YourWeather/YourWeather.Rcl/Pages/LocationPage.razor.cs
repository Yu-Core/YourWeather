using Masa.Blazor;
using System.Text.Json;
using YourWeather.Rcl.Components;
using YourWeather.Shared;

namespace YourWeather.Rcl.Pages
{
    public partial class LocationPage : PageComponentBase
    {
        private bool ShowDetails;
        private Location? Location;
        private Location CurrentLocation = new();
        private Location DetailsLocation = new();
        private List<Location> LocationDatas = new ();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Title = "位置";
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await LoadSettings();
                await InvokeAsync(StateHasChanged);
            }
        }

        private async Task LoadSettings()
        {
            var locationsJson = await SettingsService.Get<string>(SettingType.Locations);
            if (!string.IsNullOrEmpty(locationsJson))
            {
                LocationDatas = JsonSerializer.Deserialize<List<Location>>(locationsJson) ?? new();
            }

            var locationJson = await SettingsService.Get<string>(SettingType.Location);
            if (!string.IsNullOrEmpty(locationJson))
            {
                var location = JsonSerializer.Deserialize<Location>(locationJson) ?? new();
                Location = LocationDatas.FirstOrDefault(it=>it.Info == location.Info);
            }

            CurrentLocation = await LocationService.GetCurrentLocation();
        }
        private async Task SetLocation(Location? value)
        {
            Location = value;
            string? location = null;
            if(value != null)
            {
                location = JsonSerializer.Serialize(value);
            }
            await SettingsService.Save(SettingType.Location, location);
        }

        private async Task DeleteLocation(Location location)
        {
            var confirmed = await PopupService.ConfirmAsync(param =>
            {
                param.Title = "删除";
                param.Content = "确定删除这个位置吗？";
                param.OkText = "删除";
                param.CancelText = "取消";
                param.OkProps = it => { it.Color = "red"; };
            });
            if (!confirmed)
            {
                return;
            }

            if(Location != null && location.Info == Location.Info)
            {
                await SetLocation(null);
            }

            LocationDatas.Remove(location);
            var locations = JsonSerializer.Serialize(LocationDatas);
            await SettingsService.Save(SettingType.Locations, locations);
        }

        private void OpenDetails(Location? location)
        {
            DetailsLocation = location ?? new();
            ShowDetails = true;
        }
    }
}
