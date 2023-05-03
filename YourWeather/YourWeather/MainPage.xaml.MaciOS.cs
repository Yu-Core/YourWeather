using Microsoft.AspNetCore.Components.WebView;

namespace YourWeather;

public partial class MainPage
{
    // To manage iOS permissions, update Info.plist to include the necessary keys to access
    // the APIs required by your app. You may have to perform additional configuration to enable
    // use of those APIs from the WebView, as is done below.

    private partial void BlazorWebViewInitializing(object? sender, BlazorWebViewInitializingEventArgs e)
    {
        e.Configuration.AllowsInlineMediaPlayback = true;
        e.Configuration.MediaTypesRequiringUserActionForPlayback = WebKit.WKAudiovisualMediaTypes.None;
    }

    private partial void BlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e)
    {
    }
}
