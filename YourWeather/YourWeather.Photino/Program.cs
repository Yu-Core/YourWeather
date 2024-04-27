using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using YourWeather.Photino;
using YourWeather.Photino.Extensions;

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
        appBuilder.Services.AddDependencyInjection();

        var app = appBuilder.Build();

        app.MainWindow
#if DEBUG
            .SetDevToolsEnabled(true)
#endif
            .SetTitle("YourWeather.Photino")
            .SetGrantBrowserPermissions(true);
#if Windows
        app.MainWindow.WindowCreated += (sender, e) => TitleBar.Init(app.MainWindow.WindowHandle);
#endif
        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
        };

        app.Run();
    }
}