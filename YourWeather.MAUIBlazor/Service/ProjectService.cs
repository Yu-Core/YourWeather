using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model.Enum;

namespace YourWeather.MAUIBlazor.Service
{
    public class ProjectService : IProjectService
    {
        public Project Project => Project.MAUIBlazor;
    }
}
