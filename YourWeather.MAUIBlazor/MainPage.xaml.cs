using Microsoft.AspNetCore.Components.WebView;
using YourWeather.Service;
using YourWeather.MAUIBlazor.Service;

namespace YourWeather.MAUIBlazor
{
    public partial class MainPage : ContentPage
    {
        private byte BackPressCounter;
        private BackPressService BackPressService;
        public MainPage(BackPressService backPressService)
        {
            InitializeComponent();

            _blazorWebView.BlazorWebViewInitializing += BlazorWebViewInitializing;
            _blazorWebView.BlazorWebViewInitialized += BlazorWebViewInitialized;
            BackPressService= backPressService;
        }
        protected override bool OnBackButtonPressed()
        {
            if(BackPressService.HasDialogsOpen)
            {
                BackPressService.NotifyBackPressChanged();
            }
            else
            {
                TwoBack();
            }
            return true;
        }

        private partial void BlazorWebViewInitializing(object? sender, BlazorWebViewInitializingEventArgs e);
        private partial void BlazorWebViewInitialized(object? sender, BlazorWebViewInitializedEventArgs e);

        public void TwoBack()
        {
            try
            {
                if (BackPressCounter == 1)
                {
                    // DependencyService.Get<IAndroidMethods>().CloseApp();
#if ANDROID
                    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#elif IOS ||MACCATALYST
                    Thread.CurrentThread.Abort();
#elif WINDOWS
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#else
                    Environment.Exit(0);
#endif
                }
                else if (BackPressCounter == 0)
                {
                    BackPressCounter++;
                    //DependencyService.Get<BackPressMessage>().Show("Double tap to exit");
#if ANDROID
                    Android.Widget.Toast.MakeText(Android.App.Application.Context, "再按一次退出", Android.Widget.ToastLength.Long).Show();
                    Task.Run(async ()=>{
                        await Task.Delay(2000);
                        BackPressCounter = 0;
                    });
#elif IOS ||MACCATALYST
                    Thread.CurrentThread.Abort();
#elif WINDOWS
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#else
                    Environment.Exit(0);
#endif
                }
                else
                {
                    Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}