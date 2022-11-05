﻿using BlazorComponent;
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

namespace YourWeather.Razor.Shared
{
    public partial class MainLayout : IDisposable
    {
        [Inject]
        //注入主题服务
        private IThemeService? SystemThemeService { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        [Inject]
        private ISettingsService? SettingsService { get; set; }

        private bool IsDark { get;set; }

        StringNumber SelectItem = 0;

        private Settings SettingData => SettingsService.Settings;

        private static Action<int> action;

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
            return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("initSwiper", null);

                InitTheme();

            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private string? GetIcon(NavigationButton navigationButton)
        {
            return SelectItem == navigationButton.Id ? navigationButton.SelectIcon : navigationButton.Icon;
        }

        private void ChangeTheme()
        {
            IsDark = SystemThemeService!.IsDark(SettingData.ThemeState);
            InvokeAsync(StateHasChanged);
        }

        private void InitTheme()
        {
            SystemThemeService.Onchange += ChangeTheme;
            if (!OperatingSystem.IsBrowser())
            {
                SystemThemeService.ThemeChanged(SettingData.ThemeState);
            }
            else
            {
                ChangeTheme();
            }

            StateHasChanged();
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

        public void Dispose()
        {
            //if (IProjectService!.Project == Project.MAUIBlazor)
            //{
            //    SystemThemeService.Onchange -= ChangeTheme;
            //}

        }
    }
}
