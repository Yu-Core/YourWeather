

using System.Diagnostics;

namespace YourWeather.Extend
{
    public static partial class ServiceCollectionExtend
    {
        public static IServiceCollection AddMauiExceptionHandle(this IServiceCollection services)
        {
            MauiExceptions.UnhandledException += 
                (sender, args) =>
                {
#if DEBUG
                    Debug.WriteLine(args.ExceptionObject.ToString());
#endif
                };
            return services;
        }
    }
}
