using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.Blazor.HotKeys;
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
        private ISettingsService? SettingsService { get; set; }
        [Inject]
        private IThemeService? ThemeService { get; set; }
        [Inject]
        private WeatherService? WeatherService { get; set; }
        [Inject]
        private BackPressService? BackPressService { get; set; }
        [Inject]
        protected HotKeys HotKeys { get; set; }
        #endregion

        #region 变量

        protected HotKeysContext HotKeysContext;

        private bool ShowDialogExit
        {
            get => BackPressService.DialogsState[0];
            set
            {
                BackPressService.DialogsState[0] = value;
            }
        }
        private bool ShowDialogAppInformation
        {
            get => BackPressService.DialogsState[1];
            set
            {
                BackPressService.DialogsState[1] = value;
            }
        }
        private bool ShowDialogWeatherSource
        {
            get => BackPressService.DialogsState[2];
            set
            {
                BackPressService.DialogsState[2] = value;
            }
        }
        private bool ShowDialogTheme
        {
            get => BackPressService.DialogsState[3];
            set
            {
                BackPressService.DialogsState[3] = value;
            }
        }
        private bool ShowDialogSourceCode
        {
            get => BackPressService.DialogsState[4];
            set
            {
                BackPressService.DialogsState[4] = value;
            }
        }
        private bool ShowDialogLanguage
        {
            get => BackPressService.DialogsState[5];
            set
            {
                BackPressService.DialogsState[5] = value;
            }
        }
        private bool ShowDialogIndexContentManager
        {
            get => BackPressService.DialogsState[6];
            set
            {
                BackPressService.DialogsState[6] = value;
            }
        }
        private bool ShowDialogThirdPartyCopyright
        {
            get => BackPressService.DialogsState[7];
            set
            {
                BackPressService.DialogsState[7] = value;
            }
        }
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
                ShowDialogSourceCode = false;
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
                ShowDialogTheme = false;
                StateHasChanged();
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
                ShowDialogLanguage = false;
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
                ShowDialogWeatherSource = false;
                SelectWeatherSourceIndex = WeatherSourceItems.IndexOf(value);
                WeatherSourceChange();
            }
        }

        public static List<CodeSourceItem> CodeSourceItems => StaticDataService.CodeSourceItems;
        public List<LanguageItem> LanguageItems => StaticDataService.LanguageItems;
        private List<IWeatherSource> WeatherSourceItems => StaticDataService.WeatherSources;
        #endregion

        #region 方法
        protected override Task OnInitializedAsync()
        {
            SettingsService.OnInit += StateHasChanged;
            BackPressService.OnBackPressChanged += StateHasChanged;

            this.HotKeysContext = this.HotKeys.CreateContext()
              .Add(ModKeys.None, Keys.ESC, BackPressService.NotifyBackPressChanged);

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
        private void WeatherSourceChange()
        {
            WeatherService.NotifySourceChanged();
        }

        #endregion

    }
}
