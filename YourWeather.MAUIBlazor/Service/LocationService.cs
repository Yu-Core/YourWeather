using YourWeather.IService;
using YourWeather.Model.Location;

namespace YourWeather.MAUIBlazor.Service
{
    public class LocationService : ILocationService
    {
        public Task<LocationData> GetLocation()
        {
            throw new NotImplementedException();
        }
    }
}
