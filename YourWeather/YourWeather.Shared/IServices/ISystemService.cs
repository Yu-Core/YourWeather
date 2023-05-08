namespace YourWeather.Shared
{
    public interface ISystemService
    {
        Task OpenBrowserUrl(string url);
        string GetVersion();
    }
}
