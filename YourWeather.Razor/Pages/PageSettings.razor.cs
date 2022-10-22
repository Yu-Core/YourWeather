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

namespace YourWeather.Razor.Pages
{
    public partial class PageSettings
    {
        #region 注入

        [Inject]
        IJSRuntime? JS { get; set; }

        [Inject]
        private ISystemService? SystemService { get; set; }
        [Inject]
        private IProjectService? ProjectService { get; set; }

        #endregion

        #region 变量或常量
        private readonly static string githubUrl = "https://github.com/Yu-Core/YourWeather";
        private readonly static string giteeUrl = "https://gitee.com/Yu-core/YourWeather";
        private bool _dialogExit;
        private bool _dialogAppInformation;

        AssemblyName assemblyName = Assembly.GetEntryAssembly().GetName();

        string AppName => assemblyName.Name;
        string AppVersion => assemblyName.Version.ToString();

        private string _selectCodeSourceItemValue = "https://github.com/Yu-Core/YourWeather";

        private List<CodeSourceItem> CodeSourceItems = new List<CodeSourceItem>()
        {
            new CodeSourceItem("Github",githubUrl),
            new CodeSourceItem("Gitee",giteeUrl)
        };
        #endregion
        #region 类
        public class CodeSourceItem
        {
            public CodeSourceItem(string text, string value)
            {
                Text = text;
                Value = value;
            }
            public string? Text { get; set; }
            public string? Value { get; set; }
        }
        #endregion

        #region 方法
        protected override async Task OnInitializedAsync()
        {
            await JS!.InvokeVoidAsync("disableBack");
        }

        private async Task ViewSourceCode()
        {
            string url = _selectCodeSourceItemValue;
            await SystemService!.OpenLink(url);
        }

        private void ExitApp()
        {
            SystemService!.ExitApp();
        }


        #endregion

    }
}
