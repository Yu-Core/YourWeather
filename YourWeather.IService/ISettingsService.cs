using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model;

namespace YourWeather.IService
{
    public interface ISettingsService
    {
        public Settings Settings { get; }
        void SaveSetings();
    }
}
