namespace YourWeather.Shared
{
    public interface ILocationService
    {
        Task<Location> GetCurrentLocation();
        Task<List<Location>> GetAllLocations();
    }
}
