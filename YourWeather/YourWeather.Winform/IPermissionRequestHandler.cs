using Microsoft.Web.WebView2.Core;

namespace YourWeather.Winform
{
    public interface IPermissionRequestHandler
    {
        void OnPermissionRequested(CoreWebView2 sender, CoreWebView2PermissionRequestedEventArgs args);
    }
}
