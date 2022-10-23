using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model;

namespace YourWeather.Service
{
    public class SettingsService
    {
        public Settings GetSettings()
        {
            return new();
        }
        public void SaveSettings()
        {

        }
    }
}
