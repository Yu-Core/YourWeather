namespace YourWeather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

#if MACCATALYST
            window.Created += MacTitleBar.InitTitleBarForMac;
#endif
            return window;
        }
    }
}