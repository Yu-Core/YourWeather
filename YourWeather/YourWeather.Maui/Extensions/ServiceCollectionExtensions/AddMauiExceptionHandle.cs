

using System.Diagnostics;

namespace YourWeather.Maui.Extensions
{
    public static partial class ServiceCollectionExtensions
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
