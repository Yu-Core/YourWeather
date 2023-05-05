using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Interop;
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
            serviceCollection.AddCustomIOC();
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
