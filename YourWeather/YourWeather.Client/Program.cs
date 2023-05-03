using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using YourWeather.Client.Extend;
using YourWeather.Rcl;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Services.AddMasaBlazor().AddI18nForWasmAsync($"{builder.HostEnvironment.BaseAddress}/_content/YourWeather.Rcl/i18n");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IGeolocationService,GeolocationService>();
builder.Services.AddCustomIOC();

await builder.Build().RunAsync();
