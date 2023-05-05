using Microsoft.Web.WebView2.Core;

namespace YourWeather.Wpf
{
    internal interface IPermissionRequestHandler
    {
        void OnPermissionRequested(CoreWebView2 sender, CoreWebView2PermissionRequestedEventArgs args);
    }
}
