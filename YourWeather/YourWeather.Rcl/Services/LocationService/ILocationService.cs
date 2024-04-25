using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public interface ILocationService
    {
        Task<Location> GetCurrentLocation();
        Task<List<Location>> GetAllLocations();
    }
}
