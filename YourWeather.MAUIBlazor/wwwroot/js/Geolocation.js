window.watchPosition = (dotNetCallbackRef, callbackMethod) => {
    if (!navigator.geolocation) return null;

    const watchId = navigator.geolocation.watchPosition(
        (position) => {
            let result = { position: null, error: null };
            result.position = {
                coords: {
                    latitude: position.coords.latitude,
                    longitude: position.coords.longitude,
                    altitude: position.coords.altitude,
                    accuracy: position.coords.accuracy,
                    altitudeAccuracy: position.coords.altitudeAccuracy,
                    heading: position.coords.heading,
                    speed: position.coords.speed
                },
                timestamp: position.timestamp
            }
            dotNetCallbackRef.invokeMethodAsync(callbackMethod, result);
        },
        (error) => {
            let result = { position: null, error: null };
            result.error = {
                code: error.code,
                message: error.message
            }
            dotNetCallbackRef.invokeMethodAsync(callbackMethod, result);
        },
        {
            enableHighAccuracy: true,
        });
    return watchId;
};

window.clearWatch = function (id) {
    if (navigator.geolocation) {
        navigator.geolocation.clearWatch(id);
    }
};

