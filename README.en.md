# YourWeather

English | [简体中文](./README.md)

Blazor cross-platform entry-level Demo, sharing one Rcl (Razor Class Library) for multiple projects, obtains current weather and weather forecasts through weather APIs, has multiple weather sources, and can also select weather from specified locations.

Blazor WebAssembly / Blazor Server / MAUI / Winform / WPF / Photino Blazor

[Live Demo（GitHub）](https://yu-core.github.io/YourWeather/)

[Live Demo（Gitee）](https://yu-core.gitee.io/yourweather/)

## Characteristics
- Multiple weather sources
	- AMap
	- OpenWeather
	- QWeather
	- SeniverseWeather
	- VisualCrossing
- Positioning
	- Through [Darnton. Blazor. DeviceInterop](https://github.com/darnton/BlazorDeviceInterop) Implementation
	- Location permission reference in Maui Blazor [Maui BlazorPermissionsExample](https://github.com/MackinnonBuck/MauiBlazorPermissionsExample )
- Persistence storage
	- Using LocalStorage in Blazor WebAssembly and Blazor Server
	- Using the preferences provided by Maui in Maui Blazor
	- Using LocalStorage in Winform、WPF
	- Using LocalStorage in Photino
- Theme switching
	- By [MASA. Blazor](https://github.com/BlazorComponent/MASA.Blazor) Provide
	- Additional support for following system theme
	- Additional support for changing the color of Maui's status bar/title bar
	- Additional support for Winform、WPF title bar dark mode
	- Additional support for Photino Windows title bar dark mode
- Opening external links using default browser
	- Creating `<a>` tag through JavaScript

## Screenshot
<table>
	<tr>
		<td>Blazor WebAssembly</td>
		<td>Blazor Server</td>
		<td>MAUI Android</td>
	</tr>
	<tr>
		<td><img src="https://github.com/Yu-Core/YourWeather/assets/96511239/3001356d-55ef-4c95-8200-81fe6cb12e48"/></td>
		<td><img src="https://github.com/Yu-Core/YourWeather/assets/96511239/2ef5c1d2-9954-4f99-80ae-9540ba9aeb1e"/></td>
		<td rowspan="3"><img src="https://github.com/Yu-Core/YourWeather/assets/96511239/c4eb9369-f8a2-49d8-8b47-fe3bec68a2b5"/></td>
	</tr>
	<tr>
		<td>Winform</td>
		<td>WPF</td>
	</tr>
	<tr>
		<td><img src="https://github.com/Yu-Core/YourWeather/assets/96511239/b98c602f-c136-4553-a604-58a391f6e502"/></td>
		<td><img src="https://github.com/Yu-Core/YourWeather/assets/96511239/8aa96bfb-144a-417f-b3fb-757f852f0ecf"/></td>
	</tr>
	<tr>
		<td>MAUI Windows</td>
		<td>Photino Linux ( Deepin )</td>
	</tr>
	<tr>
		<td><img src="https://github.com/Yu-Core/YourWeather/assets/96511239/8ebe9733-5713-4430-94a6-c512ec6e32e0"/></td>
		<td><img src="https://github.com/Yu-Core/YourWeather/assets/96511239/d89e4562-0c08-4dba-a22a-a4265d6336d1"/></td>
	</tr>
</table>

## Related technologies
- Front end framework: Blazor
- UI component library: Masa Blazor
- Cross platform UI framework: Maui
- Desktop UI framework: Winform, WPF
- Lightweight cross platform framework

## Project structure
For details [./YourWeather/README.md](./YourWeather/README.md)

## Supported Platforms
- Web
	- Blazor WebAssembly
	- Blazor Server
- Windows
	- Maui Blazor
	- Winform (Blazor Hybrid)
	- WPF (Blazor Hybrid)
	- Photino Blazor
- Linux
	- Photino Blazor
	> If unable to run on Linux, please refer to [here](https://github.com/tryphotino/photino.Blazor/issues/81)
- Android
	- Maui Blazor
- iOS
	- Maui Blazor
- Mac
	- Maui Blazor
	- Photino Blazor

## Thank you for the following open source projects
- [.NET MAUI]( https://github.com/dotnet/maui )
- [AreaCity-JsSpider-StatsGov]( https://github.com/xiangyuecn/AreaCity-JsSpider-StatsGov )
- [ASP.NET Core]( https://github.com/dotnet/aspnetcore )
- [Blazored.LocalStorage]( https://github.com/Blazored/LocalStorage )
- [Darnton.Blazor.DeviceInterop]( https://github.com/darnton/BlazorDeviceInterop )
- [MASA.Blazor]( https://github.com/BlazorComponent/MASA.Blazor )
- [Masa.Template]( https://github.com/masastack/MASA.Template )
- [MauiBlazorPermissionsExample]( https://github.com/MackinnonBuck/MauiBlazorPermissionsExample )
- [MauiBlazorToolkit](https://github.com/Yu-Core/MauiBlazorToolkit)
- [P/Invoke](https://github.com/dotnet/pinvoke)
- [Photino.Blazor](https://github.com/tryphotino/photino.Blazor)
- [QWeather Icons]( https://github.com/qwd/Icons )
> The above rankings are in no particular order
