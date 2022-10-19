using BlazorComponent;
using Masa.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Shared
{
    public partial class MainLayout
    {

        StringNumber SelectItem = 0;
        List<NavigationButton> NavigationButtons = new List<NavigationButton>()
        {
            new NavigationButton(){Id=0,Title="天气",Icon="mdi-cloud-outline",SelectIcon="mdi-cloud",Href="/"},
            new NavigationButton(){Id=1,Title="位置",Icon="mdi-map-marker-outline",SelectIcon="mdi-map-marker",Href="/Location"},
            new NavigationButton(){Id=2,Title="设置",Icon="mdi-cog-outline",SelectIcon="mdi-cog",Href="/Settings"}
        };
        private class NavigationButton
        {
            public int Id;
            public string Title { get; set; }
            public string Icon { get; set; }
            public string SelectIcon { get; set; }
            public string Href { get; set; }
        }
        private string GetIcon(NavigationButton navigationButton)
        {
            return SelectItem == navigationButton.Id ? navigationButton.SelectIcon : navigationButton.Icon;
        }
    }
}
