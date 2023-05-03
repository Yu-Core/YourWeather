using Microsoft.AspNetCore.Components;

namespace YourWeather.Rcl.Components
{
    public partial class WeatherLivesInfoCard
    {
        [Parameter]
        public string? Value { get; set; }
        [Parameter]
        public string? Name { get; set; }
        [Parameter]
        public string? Icon { get; set; }
        [Parameter]
        public string? Unit { get; set; }
    }
}
