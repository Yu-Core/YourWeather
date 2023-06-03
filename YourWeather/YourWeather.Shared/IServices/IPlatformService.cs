namespace YourWeather.Shared
{
    public interface IPlatformService
    {
        Task OpenBrowserUrl(string url);
        string GetVersion();
    }
}
