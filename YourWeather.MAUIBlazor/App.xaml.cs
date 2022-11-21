using YourWeather.Service;

namespace YourWeather.MAUIBlazor
{
    public partial class App : Application
    {
        public App(BackPressService backPressService)
        {
            InitializeComponent();

            MainPage = new MainPage(backPressService);
        }
    }
}