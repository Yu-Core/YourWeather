using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.IService
{
    public interface IBrowserService
    {
        Task OpenLink(string Url);
    }
}
