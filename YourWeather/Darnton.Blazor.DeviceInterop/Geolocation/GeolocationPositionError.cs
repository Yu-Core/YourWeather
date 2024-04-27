using System;

namespace Darnton.Blazor.DeviceInterop.Geolocation
{
    /// <summary>
    /// The reason for a Geolocation error, based on <see href="https://developer.mozilla.org/en-US/docs/Web/API/GeolocationPositionError"/>.
    /// </summary>
    public class GeolocationPositionError
    {
        /// <summary>
        /// The <see cref="GeolocationPositionErrorCode"/> for the error.
        /// </summary>
        public GeolocationPositionErrorCode Code { get; set; }

        /// <summary>
        /// Details of the error. Intended for debugging rather than display to the user.
        /// </summary>
        public string Message { get; set; }
    }
}
