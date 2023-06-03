using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using YourWeather.Rcl.Shared;
using YourWeather.Shared;

namespace YourWeather.Rcl.Components
{
    public class PageComponentBase : ComponentBase
    {
        private string? _title;

        [Inject]
        protected ISettingsService SettingsService { get; set; } = default!;
        [Inject]
        protected IThemeService ThemeService { get; set; } = default!;
        [Inject]
        protected IWeatherService WeatherService { get; set; } = default!;
        [Inject]
        protected IPopupService PopupService { get; set; } = default!;
        [Inject]
        protected ILocationService LocationService { get; set; } = default!;
        [Inject]
        protected IPlatformService PlatformService { get; set; } = default!;
        [Inject]
        protected NavigationManager Navigation { get; set; } = default!;

        [CascadingParameter]
        public MainLayout MainLayout { get; set; } = default!;

        protected virtual string? Title
        {
            get => _title;
            set => SetTitle(value);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private void SetTitle(string? value)
        {
            _title = value;
            UpdateTitle(value);
        }

        private void UpdateTitle(string? value)
        {
            MainLayout.UpdateTitle(value);
        }
    }
}
