using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using YourWeather.Photino;
using YourWeather.Photino.Extend;
using YourWeather.Rcl;

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
            .SetTitle("YourWeather.Photino");

        app.MainWindow.WindowCreated += (sender, e) => TitleBar.Init(app.MainWindow.WindowHandle);

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
        };

        app.Run();
    }
}