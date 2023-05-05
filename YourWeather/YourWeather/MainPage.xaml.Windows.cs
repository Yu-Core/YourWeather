using Microsoft.AspNetCore.Components.WebView;
using YourWeather.Platforms.Windows;

namespace YourWeather;

public partial class MainPage
{
    // It might be perfectly acceptable to not override the WebView2 permission requesting behavior
    // at all, relying on the default popup to decide whether to grant specific permissions. However,
    // one reason to override this behavior is to prevent the user from getting "stuck" if they accidentally
    // deny a permission requested by the WebView. In an actual web browser, the user could change their
    // decision using the browser's UI, but no such UI is built in to the WebView2 control. This
    // leaves it up to us to decide what to do in these cases.
    //
    // One option is to take a simple approach, allowing all permission requests originating from
    // the base URI while denying all requests coming from an unknown source. No action from the user is
    // required. This results in a user experience that matches what one might expect from a typical
    // native Windows app.
    //
    // Alternatively, you could implement a dialog system that prompts the user when a device permission
    // is requested. This allows the user to view the details of the request and make a decision for themselves.
    //
    // This example includes both implementations. You can switch between them by adding/removing the line in
    // the .csproj file defining the HANDLE_WEBVIEW2_PERMISSIONS_SILENTLY constant.

    private partial void BlazorWebViewInitializing(object sender, BlazorWebViewInitializingEventArgs e)
    {
    }

    private partial void BlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e)
    {
        var permissionHandler = new SilentPermissionRequestHandler();

        e.WebView.CoreWebView2.PermissionRequested += permissionHandler.OnPermissionRequested;
    }
}
