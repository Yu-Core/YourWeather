using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.AspNetCore.Components.WebView;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Interop;
using YourWeather.Rcl.Desktop;
using YourWeather.Wpf.Extend;

namespace YourWeather.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var hwnd = new WindowInteropHelper(GetWindow(this)).EnsureHandle();
            TitleBar.Init(hwnd);
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
#if DEBUG
            serviceCollection.AddBlazorWebViewDeveloperTools();
#endif
            serviceCollection.AddMasaBlazor();
            serviceCollection.AddBlazoredLocalStorage();
            serviceCollection.AddScoped<IGeolocationService, GeolocationService>();
            serviceCollection.AddDependencyInjection();

            blazorWebView.BlazorWebViewInitializing += BlazorWebViewInitializing;
            blazorWebView.BlazorWebViewInitialized += BlazorWebViewInitialized;
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }

        private void BlazorWebViewInitializing(object? sender, BlazorWebViewInitializingEventArgs e)
        {
        }

        private void BlazorWebViewInitialized(object? sender, BlazorWebViewInitializedEventArgs e)
        {
            var permissionHandler = new SilentPermissionRequestHandler();

            e.WebView.CoreWebView2.PermissionRequested += (s, e) => permissionHandler.OnPermissionRequested((Microsoft.Web.WebView2.Core.CoreWebView2)s!, e);
        }
    }
}
