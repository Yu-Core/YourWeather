using YourWeather.IService;
using YourWeather.Model.Enum;

namespace YourWeather.BlazorWasm.Service
{
    public class ProjectService : IProjectService
    {
        public Project Project => Project.BlazorWasm;
    }
}
