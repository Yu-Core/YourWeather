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

        #region 变量或常量
        private const string mdi_gitee = "m12.18134,22.14583q2.09582,0 3.93968,-0.78836t3.24108,-2.17226q1.39721,-1.38389 2.19317,-3.21017t0.79595,-3.90212q0,-2.07584 -0.79595,-3.90212t-2.19317,-3.21017q-1.39721,-1.38389 -3.24108,-2.17226t-3.93968,-0.78836q-2.10727,0 -3.95114,0.78836t-3.24108,2.17226q-1.39721,1.38389 -2.19317,3.21017t-0.79595,3.90212q0,2.07584 0.79595,3.90212t2.19317,3.21017q1.39721,1.38389 3.24108,2.17226t3.95114,0.78836zm2.27906,-4.53735l-7.43272,0q-0.19469,0 -0.3493,-0.15881t-0.15461,-0.3403l0,-6.98752q0,-1.00956 0.49819,-1.85464t1.34568,-1.35553q0.84749,-0.51045 1.90113,-0.51045l7.05478,0q0.19469,0 0.3493,0.15881t0.15461,0.35164l0,1.25911q0,0.18149 -0.15461,0.3403t-0.3493,0.15881l-7.05478,0q-0.61844,0 -1.07082,0.44806t-0.45238,1.06061l0,4.7869q0,0.19284 0.16034,0.34597t0.34358,0.15314l4.76427,0q0.62989,0 1.08227,-0.44806t0.45238,-1.06061l0,-0.24955q0,-0.19284 -0.16034,-0.34597t-0.35503,-0.15314l-3.49303,0q-0.19469,0 -0.3493,-0.15881t-0.15461,-0.35164l0,-1.25911q0,-0.18149 0.15461,-0.3403t0.3493,-0.15881l5.78355,0q0.19469,0 0.3493,0.15881t0.15461,0.3403l0,2.83584q0,1.37255 -0.99065,2.35375t-2.37641,0.9812z";
        private const string githubUrl = "https://github.com/Yu-Core/YourWeather";
        private const string giteeUrl = "https://gitee.com/Yu-core/YourWeather";
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

        private readonly static List<CodeSourceItem> CodeSourceItems = new List<CodeSourceItem>()
        {
            new CodeSourceItem("Github",githubUrl,"mdi-github"),
            new CodeSourceItem("Gitee",giteeUrl,mdi_gitee)
        };
        private List<WeatherSource> WeatherSources => WeatherService!.GetWeatherSources();
        #endregion
        #region 类
        public class CodeSourceItem
        {
            public CodeSourceItem(string text, string value, string? icon)
            {
                Text = text;
                Value = value;
                Icon = icon;
            }
            public string? Text { get; set; }
            public string? Value { get; set; }
            public string? Icon { get; set; }
        }
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
