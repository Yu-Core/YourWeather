using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Model.Enum;
using YourWeather.Model.Item;
using YourWeather.Model.Weather.WeatherSource;
using YourWeather.Service;

namespace YourWeather.Razor.Pages
{
    public partial class PageSettings
    {
        #region 注入

        [Inject]
        private ISystemService? SystemService { get; set; }
        [Inject]
        private IProjectService? ProjectService { get; set; }
        [Inject]
        private ISettingsService? SettingsService { get; set; }
        [Inject]
        private IThemeService? ThemeService { get; set; }

        #endregion

        #region 变量

        private bool _dialogExit;
        private bool _dialogAppInformation;
        private bool _dialogWeatherSource;
        private bool _dialogTheme;
        private bool _dialogSourceCode;
        private bool _dialogLanguage;
        private bool SwitchTheme
        {
            get
            {
                return ThemeState == ThemeState.Dark;
            }
            set
            {
                ThemeState = value ? ThemeState.Dark : ThemeState.Light;
            }
        }
        private Settings SettinsData => SettingsService.Settings;
        private Project Project => ProjectService!.Project;

        private string AppVersion => SystemService!.GetAppVersion();
        
        private int SelectCodeSourceIndex
        {
            get => SettinsData.CodeSource;
            set
            {
                SettinsData.CodeSource = value;
            }
        }
        private CodeSourceItem SelectCodeSourceItem
        {
            get => CodeSourceItems[SelectCodeSourceIndex];
            set
            {
                _dialogSourceCode = false;
                SelectCodeSourceIndex = CodeSourceItems.IndexOf(value);
            }
        }
        private bool IsDark()
        {
            return ThemeService.IsDark(ThemeState);
        }

        //应用的主题状态
        private ThemeState ThemeState
        {
            get => SettinsData.ThemeState;
            set
            {
                _dialogTheme = false;
                SettinsData.ThemeState = value;
                ThemeChanged();
            }
        }
        private int SelectLanguageIndex
        {
            get => SettinsData.Language;
            set
            {
                SettinsData.Language = value;
            }
        }
        private LanguageItem SelectLanguageItem
        {
            get => LanguageItems[SelectLanguageIndex];
            set
            {
                _dialogLanguage = false;
                SelectLanguageIndex = LanguageItems.IndexOf(value);
            }
        }

        private int SelectWeatherSourceIndex
        {
            get => SettinsData.WeatherSource;
            set
            {
                SettinsData.WeatherSource = value;
            }
        }

        private IWeatherSource SelectWeatherSourceItem
        {
            get => WeatherSourceItems[SelectWeatherSourceIndex];
            set
            {
                _dialogWeatherSource = false;
                SelectWeatherSourceIndex = WeatherSourceItems.IndexOf(value);
            }
        }

        public List<CodeSourceItem> CodeSourceItems => StaticDataService.CodeSourceItems;
        public List<LanguageItem> LanguageItems => StaticDataService.LanguageItems;
        private List<IWeatherSource> WeatherSourceItems => StaticDataService.WeatherSources;
        #endregion

        #region 方法
        protected override  Task OnInitializedAsync()
        {
            SettingsService.OnChange += StateHasChanged;
           return base.OnInitializedAsync();
        }

        private async Task ViewSourceCode()
        {
            string url = SelectCodeSourceItem.Value!;
            await SystemService!.OpenLink(url);
        }
        private void ExitApp()
        {
            SystemService!.ExitApp();
        }

        //主题状态更改
        private void ThemeChanged()
        {
            ThemeService.ThemeChanged(SettinsData.ThemeState);
        }

        #endregion

    }
}
