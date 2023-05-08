using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.AspNetCore.Components.WebView;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using YourWeather.Rcl;
using YourWeather.Rcl.Desktop;
using YourWeather.Winform.Extend;
using GeolocationService = YourWeather.Rcl.Desktop.Services.GeolocationService;

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
            blazorWebView.BlazorWebViewInitializing += BlazorWebViewInitializing;
            blazorWebView.BlazorWebViewInitialized += BlazorWebViewInitialized;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }

        private void BlazorWebViewInitializing(object? sender, BlazorWebViewInitializingEventArgs e)
        {
        }

        private void BlazorWebViewInitialized(object? sender, BlazorWebViewInitializedEventArgs e)
        {
            var permissionHandler = new SilentPermissionRequestHandler();

            e.WebView.CoreWebView2.PermissionRequested += (s,e) => permissionHandler.OnPermissionRequested((Microsoft.Web.WebView2.Core.CoreWebView2)s!,e);
        }
    }
}