using BlazorComponent.I18n;
using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using YourWeather.BlazorWasm;
using YourWeather.BlazorWasm.Extend;
using YourWeather.Razor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMasaBlazor();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IGeolocationService, GeolocationService>();

builder.Services.AddCustomIOC();

await builder.Build().RunAsync();
