namespace YourWeather.Rcl.Services
{
    public interface IPlatformIntegration
    {
        Task OpenBrowserUrl(string url);
        string GetVersion();
    }
}
