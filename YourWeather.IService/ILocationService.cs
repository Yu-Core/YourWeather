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
        public LocationData? SelectedLocation { get; set; }
        public List<LocationData>? ChinaCities { get;set; }
        public void InitCurrentLocation();

        public event Action<Result<LocationData>>? OnLocationChanged;
    }
}
