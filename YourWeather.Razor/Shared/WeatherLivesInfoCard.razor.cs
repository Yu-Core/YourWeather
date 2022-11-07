using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Razor.Shared
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
