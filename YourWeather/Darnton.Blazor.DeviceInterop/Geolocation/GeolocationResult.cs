using System;
using System.Text.Json.Serialization;

namespace Darnton.Blazor.DeviceInterop.Geolocation
{
    /// <summary>
    /// The result of a geolocation request. Contains either a <see cref="GeolocationPosition"/> or a <see cref="GeolocationPositionError"/>.
    /// </summary>
    public class GeolocationResult
    {
        /// <summary>
        /// The <see cref="GeolocationPosition"/> returned on successful geolocation.
        /// </summary>
        public GeolocationPosition Position { get; set; }
        /// <summary>
        /// The <see cref="GeolocationPositionError"/> returned by a failed geolocation attempt.
        /// </summary>
        public GeolocationPositionError Error { get; set; }

        /// <summary>
        /// Indicates whether the geolocation attempt was successful.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess => !(Position is null);
    }
}
