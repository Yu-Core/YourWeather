namespace YourWeather.MAUIBlazor
{
    public partial class MainPage : ContentPage
    {
        byte BackPressCounter = 1;
        public MainPage()
        {
            InitializeComponent();

        }
        protected override bool OnBackButtonPressed()
        {
            try
            {
                if (BackPressCounter == 2)
                {
                    // DependencyService.Get<IAndroidMethods>().CloseApp();
#if ANDROID
                    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#elif IOS
                    Thread.CurrentThread.Abort();
#elif MACCATALYST
                    Thread.CurrentThread.Abort();
#elif WINDOWS
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#else
                    Environment.Exit(0);
#endif
                }
                else if (BackPressCounter == 1)
                {
                    BackPressCounter++;
                    //DependencyService.Get<BackPressMessage>().Show("Double tap to exit");
#if ANDROID
                    Android.Widget.Toast.MakeText(Android.App.Application.Context, "再按一次退出", Android.Widget.ToastLength.Long).Show();
#elif IOS
                    Thread.CurrentThread.Abort();
#elif MACCATALYST
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
            return true;
        }
    }
}