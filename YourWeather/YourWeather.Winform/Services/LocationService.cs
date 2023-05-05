﻿using Darnton.Blazor.DeviceInterop.Geolocation;

namespace YourWeather.Winform.Services
{
    public class LocationService : Rcl.Services.LocationService
    {
        public LocationService(IGeolocationService geolocationService) : base(geolocationService)
        {

        }
    }
}
