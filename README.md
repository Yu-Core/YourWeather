# YourWeather

[English](./README.en.md) | 简体中文

Blazor 跨平台入门级Demo，多个项目共用一个Rcl（Razor类库），通过天气API获取当前天气和天气预报，具有多个天气源，也可以选择指定位置的天气。

Blazor WebAssembly / Blazor Server / MAUI / Winform / WPF / Photino Blazor

[在线演示地址（GitHub）](https://yu-core.github.io/YourWeather/)

[在线演示地址（Gitee）](https://yu-core.gitee.io/yourweather/)

## 特点
- 多个天气源
	- 高德地图
	- OpenWeather
	- 和风天气
	- 心知天气
	- VisualCrossing
- 定位
	- 通过 [Darnton.Blazor.DeviceInterop](https://github.com/darnton/BlazorDeviceInterop) 实现
	- Maui Blazor 中的定位权限参考 [MauiBlazorPermissionsExample](https://github.com/MackinnonBuck/MauiBlazorPermissionsExample)
- 持久化存储
	- Blazor WebAssembly 和 Blazor Server 中使用 localStorage
	- Maui Blazor 中使用 Maui 提供的首选项
	- Winform、WPF 中使用 localStorage
	- Photino 中使用 localStorage
- 主题切换
	- 由 [MASA.Blazor](https://github.com/BlazorComponent/MASA.Blazor) 提供
	- 额外支持 跟随系统主题
	- 额外支持 Maui 状态栏/标题栏的颜色改变
	- 额外支持 Winform、WPF 标题栏深色模式
	- 额外支持 Photino 的 Windows标题栏深色模式
- 使用默认浏览器打开外部链接
	- 通过js创建a标签

## 截图
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

## 相关技术
- 前端框架：Blazor
- UI组件库：Masa Blazor
- 跨平台UI框架：Maui
- 桌面端UI框架：Winform、WPF
- 轻量级跨平台框架：Photino

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
	- Photino Blazor
- Linux
	- Photino Blazor
	> Linux上无法运行请参考[这里](https://github.com/tryphotino/photino.Blazor/issues/81)
- Android
	- Maui Blazor
- iOS
	- Maui Blazor
- Mac
	- Maui Blazor
	- Photino Blazor

## 感谢以下开源项目
- [.NET MAUI](https://github.com/dotnet/maui)
- [AreaCity-JsSpider-StatsGov](https://github.com/xiangyuecn/AreaCity-JsSpider-StatsGov)
- [ASP.NET Core](https://github.com/dotnet/aspnetcore)
- [Blazored.LocalStorage](https://github.com/Blazored/LocalStorage)
- [Darnton.Blazor.DeviceInterop](https://github.com/darnton/BlazorDeviceInterop)
- [MASA.Blazor](https://github.com/BlazorComponent/MASA.Blazor)
- [Masa.Template](https://github.com/masastack/MASA.Template)
- [MauiBlazorPermissionsExample](https://github.com/MackinnonBuck/MauiBlazorPermissionsExample)
- [MauiBlazorToolkit](https://github.com/Yu-Core/MauiBlazorToolkit)
- [P/Invoke](https://github.com/dotnet/pinvoke)
- [Photino.Blazor](https://github.com/tryphotino/photino.Blazor)
- [QWeather Icons](https://github.com/qwd/Icons)
> 以上排名不分先后
