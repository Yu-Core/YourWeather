using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Location;
using YourWeather.Model.Result;

namespace YourWeather.IService
{
    public interface ILocationService
    {
        Task<Result<LocationData>> GetLocation();
    }
}
