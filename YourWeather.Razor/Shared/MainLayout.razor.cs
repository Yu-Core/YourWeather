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
using YourWeather.Model;
using YourWeather.Model.Enum;
using YourWeather.Service;

namespace YourWeather.Razor.Shared
{
    public partial class MainLayout 
    {
        [Inject]
        private MasaBlazor MasaBlazor { get; set; }
        [Inject]
        //注入主题服务
        private IThemeService? ThemeService { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        [Inject]
        private ISettingsService? SettingsService { get; set; }
        [Inject]
        private ILocationService? LocationService { get; set; }

        private bool IsDark
        {
            get => ThemeService.IsDark(SettingData.ThemeState);
        }

        StringNumber SelectItem = 0;

        private Settings SettingData => SettingsService.Settings;

        private static Action<int> action;

        private bool _overlay = true;

        readonly List<NavigationButton> NavigationButtons = new()
        {
            new NavigationButton(0,"天气","mdi-cloud-outline","mdi-cloud"),
            new NavigationButton(1,"位置","mdi-map-marker-outline","mdi-map-marker"),
            new NavigationButton(2,"设置","mdi-cog-outline","mdi-cog")
        };
        private class NavigationButton
        {
            public NavigationButton(int id, string title, string icon, string selectIcon)
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
            ThemeService.Onchange += StateHasChanged;
            SettingsService.OnInit += StateHasChanged;
            LocationService.OnInitVoid += () =>{ _overlay = false; StateHasChanged(); };
            MasaBlazor.Breakpoint.OnUpdate += () => { return InvokeAsync(StateHasChanged); };
            return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("initSwiper", null);
                //InitTheme();

            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private string? GetIcon(NavigationButton navigationButton)
        {
            return SelectItem == navigationButton.Id ? navigationButton.SelectIcon : navigationButton.Icon;
        }

        //private void ChangeTheme()
        //{
        //    IsDark = SystemThemeService!.IsDark(SettingData.ThemeState);
        //    InvokeAsync(StateHasChanged);
        //}

        //private void InitTheme()
        //{
        //    SystemThemeService.Onchange += ChangeTheme;
        //    if (!OperatingSystem.IsBrowser())
        //    {
        //        SystemThemeService.ThemeChanged(SettingData.ThemeState);
        //    }
        //    else
        //    {
        //        ChangeTheme();
        //    }

        //    StateHasChanged();
        //}


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

        //public void Dispose()
        //{
        //    SystemThemeService.Onchange -= ChangeTheme;
        //    if (!OperatingSystem.IsBrowser())
        //    {
        //        SystemThemeService.ThemeChanged(ThemeState.Light);
        //    }
        //}

    }
}
