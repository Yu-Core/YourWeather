using AndroidX.Activity;
using Microsoft.AspNetCore.Components.WebView;
using Microsoft.Maui.Platform;
using YourWeather.Maui.Platforms.Android;

namespace YourWeather.Maui;

public partial class MainPage
{
    // To manage Android permissions, update AndroidManifest.xml to include the permissions and
    // features required by your app. You may have to perform additional configuration to enable
    // use of those APIs from the WebView, as is done below. A custom WebChromeClient is needed
    // to define what happens when the WebView requests a set of permissions. See
    // PermissionManagingBlazorWebChromeClient.cs to explore the approach taken in this example.

    private partial void BlazorWebViewInitializing(object sender, BlazorWebViewInitializingEventArgs e)
    {
    }

    private partial void BlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e)
    {
        if (e.WebView.Context?.GetActivity() is not ComponentActivity activity)
        {
            throw new InvalidOperationException($"The permission-managing WebChromeClient requires that the current activity be a '{nameof(ComponentActivity)}'.");
        }

        e.WebView.VerticalScrollBarEnabled = false;
        e.WebView.Settings.JavaScriptEnabled = true;
        e.WebView.Settings.AllowFileAccess = true;
        e.WebView.Settings.MediaPlaybackRequiresUserGesture = false;
        e.WebView.Settings.SetGeolocationEnabled(true);
        e.WebView.Settings.SetGeolocationDatabasePath(e.WebView.Context.FilesDir.Path);
        e.WebView.SetWebChromeClient(new PermissionManagingBlazorWebChromeClient(e.WebView.WebChromeClient, activity));
    }
}
