namespace YourWeather.Shared
{
    public interface IPlatformService
    {
        Task<T> ReadJsonAsync<T>(string baseUri);
        Task OpenBrowserUrl(string url);
        string GetVersion();
    }
}
