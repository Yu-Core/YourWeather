namespace YourWeather.Rcl.Services
{
    public interface IPlatformIntegration
    {
        Task<T> ReadJsonAsync<T>(string baseUri);
        Task OpenBrowserUrl(string url);
        string GetVersion();
    }
}
