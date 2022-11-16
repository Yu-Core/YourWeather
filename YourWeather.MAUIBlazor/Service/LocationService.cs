using Darnton.Blazor.DeviceInterop.Geolocation;
using YourWeather.IService;
using YourWeather.Model.Location;
using YourWeather.Model.Result;

namespace YourWeather.MAUIBlazor.Service
{
    public class LocationService : ILocationService
    {
        //private LocationData CurrentLocation;

        //public LocationData SelectedLocation { get; set; }

        //public async Task<Result<LocationData>> GetCurrentLocation()
        //{
        //    if(null == CurrentLocation)
        //    {
        //        PermissionStatus status = await CheckAndRequestLocationPermission();
        //        if (status != PermissionStatus.Granted)
        //        {
        //            return ResultHelper.Error<LocationData>("PERMISSION_DENIED");
        //        }

        //        try
        //        {
        //            Location location = await Geolocation.Default.GetLastKnownLocationAsync();
        //        }
        //        catch (FeatureNotSupportedException)
        //        {
        //            return ResultHelper.Error<LocationData>("DEVICE_NOT_SUPPORTED");
        //        }
        //        catch (FeatureNotEnabledException)
        //        {
        //            return ResultHelper.Error<LocationData>("POSITION_UNAVAILABLE");
        //        }
        //        catch (PermissionException)
        //        {
        //            return ResultHelper.Error<LocationData>("PERMISSION_DENIED");
        //        }

        //        catch (Exception ex)
        //        {
        //            return ResultHelper.Error<LocationData>(ex.Message);
        //        }

        //    }
        //    return ResultHelper.Success(CurrentLocation);
        //}

        //public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        //{
        //    PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        //    if (status == PermissionStatus.Granted)
        //        return status;

        //    if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        //    {
        //        // Prompt the user to turn on in settings
        //        // On iOS once a permission has been denied it may not be requested again from the application
        //        return status;
        //    }

        //    if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
        //    {
        //        // Prompt the user with additional information as to why the permission is needed
        //        return PermissionStatus.Denied;
        //    }

        //    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        //    return status;
        //}

        private IGeolocationService GeolocationService { get; set; }
        public LocationData SelectedLocation { get; set; }

        public LocationService(IGeolocationService geolocationService)
        {
            GeolocationService = geolocationService;
        }
        private LocationData CurrentLocation;
        public async Task<Result<LocationData>> GetCurrentLocation()
        {
            if (CurrentLocation == null)
            {
                var currentPositionResult = await GeolocationService.GetCurrentPosition();

                if (currentPositionResult.IsSuccess)
                {
                    CurrentLocation = new LocationData()
                    {
                        Latitude = currentPositionResult.Position.Coords.Latitude,
                        Longitude = currentPositionResult.Position.Coords.Longitude,
                    };
                    SelectedLocation = CurrentLocation;
                }
                else
                {
                    return ResultHelper.Error<LocationData>(currentPositionResult.Error.Code.ToString());
                }
            }

            return ResultHelper.Success(CurrentLocation);
        }
    }
}
