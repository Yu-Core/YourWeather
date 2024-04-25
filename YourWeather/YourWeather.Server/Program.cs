using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using YourWeather.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);
// https://github.com/dotnet/aspnetcore/issues/38212
builder.WebHost.UseStaticWebAssets();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMasaBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IGeolocationService, GeolocationService>();
builder.Services.AddDependencyInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
