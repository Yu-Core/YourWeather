using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using YourWeather.Rcl;
using YourWeather.Winform.Extend;
using GeolocationService = YourWeather.Winform.Services.GeolocationService;

namespace YourWeather.Winform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            TitleBar.Init(Handle);

            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();

#if DEBUG
            services.AddBlazorWebViewDeveloperTools();
#endif
            services.AddMasaBlazor();
            services.AddBlazoredLocalStorage();
            services.AddScoped<IGeolocationService, GeolocationService>();
            services.AddCustomIOC();
            blazorWebView.HostPage = "wwwroot\\index.html";
            blazorWebView.Services = services.BuildServiceProvider();
            blazorWebView.RootComponents.Add<App>("#app");
        }

    }
}