# YourWeather

English | [¼òÌåÖÐÎÄ](./README.md)

¡¸YourWeather¡¹is a cross platform weather application that can be run using web pages, Windows applications, Android applications, and iOS applications¡£

It can also be used as a demo for learning Blazor and MAUI Blazor£¨Of course, due to the limited level, the writing may not be very standard£©¡£

<img src="./Images/Weather.png" />

## Technology stack
- A pure front-end project
- using C#¡¢HTML¡¢CSS¡¢JS
- The project was built using Blazor. Blazor WebAssembly and MAUI Blazor share Razor class library ¡£Blazor is a framework for building interactive client-side web UI with .NET¡£
- The Web side (Blazor WebAssembly) uses [Blazored. LocalStorage]£¨ https://github.com/Blazored/LocalStorage £©The data is stored in localStorage, and other platforms (MAUI Blazor) are stored in AppData as Json files
- Left and right sliding using [Swiper](https://github.com/nolimits4web/swiper)
- Pull-to-refresh using [PulltoRefresh.js](https://github.com/BoxFactura/pulltorefresh.js)
- Shortcut key using [Toolbelt.Blazor.HotKeys](https://github.com/jsakamoto/Toolbelt.Blazor.HotKeys)


## Supported platforms
- Web
- Windows
- Android
- ~~iOS/Mac~~ (Since there is no Apple device to test, whether it can run is unknown)

## Disadvantages
- The color of Android system bar cannot change with the theme (the corresponding api is not integrated in MAUI temporarily)
- The logging function is not implemented (insufficient level)
- Multi language function is not implemented (it is difficult to implement in MAUI)
- IOS not supported (no iOS device can be tested)
- There is some confusion in the overall structure
- Only Chinese cities are available for city search
- The key of the weather source cannot be freely changed in the program (it will be improved in the future)

## Thanks for the following open source projects
- [MASA.Blazor](https://github.com/BlazorComponent/MASA.Blazor)
- [ASP.NET Core](https://github.com/dotnet/aspnetcore)
- [.NET MAUI](https://github.com/dotnet/maui)
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
- [Swiper](https://github.com/nolimits4web/swiper)
- [Blazored.LocalStorage](https://github.com/Blazored/LocalStorage)
- [Darnton.Blazor.DeviceInterop](https://github.com/darnton/BlazorDeviceInterop)
- [MauiBlazorPermissionsExample](https://github.com/MackinnonBuck/MauiBlazorPermissionsExample)
- [PulltoRefresh.js](https://github.com/BoxFactura/pulltorefresh.js)
- [.NET Runtime](https://github.com/dotnet/runtime)
- [QWeather Icons](https://github.com/qwd/Icons)
- [AreaCity-JsSpider-StatsGov](https://github.com/xiangyuecn/AreaCity-JsSpider-StatsGov)
- [CsvHelper](https://github.com/JoshClose/CsvHelper)
- [Loaders.css](https://github.com/ConnorAtherton/loaders.css)
- [Toolbelt.Blazor.HotKeys](https://github.com/jsakamoto/Toolbelt.Blazor.HotKeys)
- [Assets.Dotnet9](https://github.com/dotnet9/Assets.Dotnet9)