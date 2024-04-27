namespace Darnton.Blazor.DeviceInterop.Geolocation
{
    /// <summary>
    /// Option properties to be passed to Geolocation functions, based on https://developer.mozilla.org/en-US/docs/Web/API/PositionOptions.
    /// </summary>
    public class PositionOptions
    {
        /// <summary>
        /// Enable high accuracy mode for best possible results.
        /// May be slower or increase power consumption. Defaults to false.
        /// </summary>
        public bool EnableHighAccuracy { get; set; } = false;

        /// <summary>
        /// Maximum length of time allowed to return a position (in milliseconds).
        /// Set to null for no timeout. Defaults to null.
        /// </summary>
        public long? Timeout { get; set; } = null;

        /// <summary>
        /// Maximum allowed age for a cached result.
        /// Set to null to disregard the age of cached results.
        /// Set to 0 to skip the cache and attempt a fresh result every time. Defaults to 0.
        /// </summary>
        public long? MaximumAge { get; set; } = 0;
    }
}
