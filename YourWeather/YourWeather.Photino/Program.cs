using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using YourWeather.Photino.Services;
using YourWeather.Photino.Extend;
using YourWeather.Rcl;
using GeolocationService = YourWeather.Photino.Services.GeolocationService;

internal class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

        appBuilder.RootComponents.Add<App>("#app");
        appBuilder.Services.AddMasaBlazor();
        appBuilder.Services.AddBlazoredLocalStorage();
        appBuilder.Services.AddScoped<IGeolocationService, GeolocationService>();
        appBuilder.Services.AddCustomIOC();

        var app = appBuilder.Build();

        app.MainWindow
#if DEBUG
            .SetDevToolsEnabled(true)
#endif
            .SetTitle("YourWeather.Photino")
            .SetGrantBrowserPermissions(true)
            .SetIconFile("Resources/favicon.ico");
#if Windows
        app.MainWindow.WindowCreated += (sender, e) => TitleBar.Init(app.MainWindow.WindowHandle);
#endif
        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
        };

        app.Run();
    }
}