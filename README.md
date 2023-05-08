# YourWeather

[English](./README.en.md) | 简体中文

Blazor/Maui Blazor 入门级项目，通过天气API获取当前天气和天气预报，具有多个天气源，也可以选择指定位置的天气。

[在线演示地址](https://yu-core.github.io/YourWeather/)

## 特点
- 支持多个天气源
	- 高德地图
	- OpenWeather
	- 和风天气
	- 心知天气
	- VisualCrossing
- 支持定位
	- 通过 [Darnton.Blazor.DeviceInterop](https://github.com/darnton/BlazorDeviceInterop) 实现
	- Maui Blazor 中的定位权限参考 [MauiBlazorPermissionsExample](https://github.com/MackinnonBuck/MauiBlazorPermissionsExample)
- 支持持久化存储
	- Blazor WebAssembly 和 Blazor Server 中使用 localStorage
	- Maui Blazor 中使用 Maui 提供的首选项
	- Winform 中使用 localStorage
	- WPF 中使用 localStorage
- 支持主题切换
	- 由 [MASA.Blazor](https://github.com/BlazorComponent/MASA.Blazor) 提供
	- 额外支持 Maui 状态栏/标题栏的颜色改变
	- 额外支持 Winform 标题栏深色模式
	- 额外支持 WPF 标题栏深色模式
- 支持使用默认浏览器打开外部链接
	- Blazor WebAssembly 和 Blazor Server 中通过js创建a标签
	- Maui Blazor 中使用 Maui 提供的 api
	- Winform 和 WPF 中通过cmd

## 截图
<table>
	<tr>
		<td>Blazor WebAssembly</td>
		<td>Blazor Server</td>
		<td>MAUI Android</td>
	</tr>
	<tr>
		<td><img src="./Images/Blazor-Wasm.png"/></td>
		<td><img src="./Images/Blazor-SSR.png"/></td>
		<td rowspan="3"><img src="./Images/MAUI-Android.jpg"/></td>
	</tr>
	<tr>
		<td>Winform</td>
		<td>WPF</td>
	</tr>
	<tr>
		<td><img src="./Images/Winform.png"/></td>
		<td><img src="./Images/WPF.png"/></td>
	</tr>
	<tr>
		<td>MAUI Windows</td>
	</tr>
	<tr>
		<td><img src="./Images/MAUI-Windows.png"/></td>
	</tr>
</table>

## 相关技术
- 前端框架：Blazor
- 跨平台UI框架：Maui
- 桌面端UI框架：Winform、WPF
- UI组件库：Masa Blazor

## 项目结构
详见[./YourWeather/README.md](./YourWeather/README.md)

## 支持的平台
- Web
	- Blazor WebAssembly
	- Blazor Server
- Windows
	- Maui Blazor
	- Winform (Blazor Hybrid)
	- WPF (Blazor Hybrid)
- Android
	- Maui Blazor
- iOS
	- Maui Blazor
- Mac
	- Maui Blazor

## 感谢以下开源项目
- [.NET MAUI](https://github.com/dotnet/maui)
- [AreaCity-JsSpider-StatsGov](https://github.com/xiangyuecn/AreaCity-JsSpider-StatsGov)
- [ASP.NET Core](https://github.com/dotnet/aspnetcore)
- [Blazored.LocalStorage](https://github.com/Blazored/LocalStorage)
- [Darnton.Blazor.DeviceInterop](https://github.com/darnton/BlazorDeviceInterop)
- [MASA.Blazor](https://github.com/BlazorComponent/MASA.Blazor)
- [Masa.Template](https://github.com/masastack/MASA.Template)
- [MauiBlazorPermissionsExample](https://github.com/MackinnonBuck/MauiBlazorPermissionsExample)
- [P/Invoke](https://github.com/dotnet/pinvoke)
- [QWeather Icons](https://github.com/qwd/Icons)
> 以上排名不分先后
