using BlazorComponent;
using Masa.Blazor;
using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model.Enum;

namespace YourWeather.Razor.Shared
{
    public partial class MainLayout
    {
        [Inject]
        //注入主题服务
        private IThemeService? IThemeService { get; set; }
        [Inject]
        private IProjectService? IProjectService { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        private bool IsDark { get; set; }

        StringNumber SelectItem = 0;

        private static Action<int> action;

        readonly List<NavigationButton> NavigationButtons = new()
        {
            new NavigationButton(0,"天气","mdi-cloud-outline","mdi-cloud"),
            new NavigationButton(1,"位置","mdi-map-marker-outline","mdi-map-marker"),
            new NavigationButton(2,"设置","mdi-cog-outline","mdi-cog")
        };
        private class NavigationButton
        {
            public NavigationButton(int id,string title,string icon,string selectIcon)
            {
                Id = id;
                Title = title;
                Icon = icon;
                SelectIcon = selectIcon;
            }
            public int Id;
            public string? Title { get; set; }
            public string? Icon { get; set; }
            public string? SelectIcon { get; set; }
        }

        protected override Task OnInitializedAsync()
        {
            action = UpdateSelectItem;
            return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("initSwiper", null);

                if (IProjectService!.Project == Project.MAUIBlazor)
                {
                    // 根据系统主题是否为Dark，为IsDark属性赋值
                    IsDark = IThemeService.IsDark();
                    IThemeService.Onchange += ChangeTheme;
                    IThemeService.ThemeChanged();
                    StateHasChanged();
                }

            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private string? GetIcon(NavigationButton navigationButton)
        {
            return SelectItem == navigationButton.Id ? navigationButton.SelectIcon : navigationButton.Icon;
        }

        private void ChangeTheme()
        {
            IsDark = IThemeService!.IsDark();
            InvokeAsync(StateHasChanged);
        }

        private async Task ChangeView(int index)
        {
            await JSRuntime.InvokeVoidAsync("changeSwiperIndex", index);
        }
        private void UpdateSelectItem(int index)
        {
            SelectItem = index;
            StateHasChanged();
        }
        [JSInvokable]
        public static void ChangeDotNetIndex(int index)
        {
            action.Invoke(index);
        }
    }
}
