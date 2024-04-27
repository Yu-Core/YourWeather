using System;

namespace Darnton.Blazor.DeviceInterop.Geolocation
{
    /// <summary>
    /// Geolocation Coordinates, based on <see href="https://developer.mozilla.org/en-US/docs/Web/API/GeolocationCoordinates"/>.
    /// </summary>
    public class GeolocationCoordinates
    {
        /// <summary>
        /// Latitude in decimal degrees.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude in decimal degrees.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Altitude in metres, relative to sea level.
        /// </summary>
        public double? Altitude { get; set; }

        /// <summary>
        /// Accuracy of the latitude and longitude properties, in metres.
        /// </summary>
        public double Accuracy { get; set; }

        /// <summary>
        /// Accuracy of the altitude, in metres.
        /// </summary>
        public double? AltitudeAccuracy { get; set; }

        /// <summary>
        /// The direction the device is travelling, in degrees clockwise from true north.
        /// </summary>
        public double? Heading { get; set; }

        /// <summary>
        /// The velocity of the device, in metres per second.
        /// </summary>
        public double? Speed { get; set; }
    }
}
