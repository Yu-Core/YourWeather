using System.Text.Json;

namespace YourWeather.Rcl.Services
{
    public abstract class StaticWebAssets : IStaticWebAssets
    {
        private static readonly Lazy<string?> _rclAssemblyName = new(() => typeof(StaticWebAssets).Assembly.GetName().Name);

        protected virtual JsonSerializerOptions DefaultJsonSerializerOptions { get; } = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static string? RclAssemblyName => _rclAssemblyName.Value;

        public abstract Task<T> ReadJsonAsync<T>(string relativePath, bool isRcl = true, JsonSerializerOptions? jsonSerializerOptions = null);

        public abstract Task<string> ReadContentAsync(string relativePath, bool isRcl = true);
    }
}
