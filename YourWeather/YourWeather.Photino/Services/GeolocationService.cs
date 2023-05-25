using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.JSInterop;

namespace YourWeather.Photino.Services
{

    /// <summary>
    /// An implementation of <see cref="IGeolocationService"/> that provides 
    /// an interop layer for the device's Geolocation API.
    /// </summary>
    public class GeolocationService : IGeolocationService
    {
        private readonly JSBinder _jsBinder;

        /// <inheritdoc/>
        public event EventHandler<GeolocationEventArgs> WatchPositionReceived;

        /// <summary>
        /// Constructs a <see cref="GeolocationService"/> object.
        /// </summary>
        /// <param name="JSRuntime"></param>
        public GeolocationService(IJSRuntime JSRuntime)
        {
            _jsBinder = new JSBinder(JSRuntime, "./_content/Darnton.Blazor.DeviceInterop/js/Geolocation.js");
        }

        /// <inheritdoc/>
        public async Task<GeolocationResult> GetCurrentPosition(PositionOptions options = null)
        {
            var module = await _jsBinder.GetModule();
            return await module.InvokeAsync<GeolocationResult>("Geolocation.getCurrentPosition", options);
        }

        /// <inheritdoc/>
        public async Task<long?> WatchPosition(PositionOptions options = null)
        {
            var module = await _jsBinder.GetModule();
            var callbackObj = DotNetObjectReference.Create(this);
            return await module.InvokeAsync<int>("Geolocation.watchPosition",
                callbackObj, nameof(SetWatchPosition), options);
        }

        /// <summary>
        /// Invokes the <see cref="WatchPositionReceived"/> event handler.
        /// Invoked by the success and error callbacks of the JavaScript watchPosition() function.
        /// </summary>
        /// <param name="watchResult">A <see cref="GeolocationResult"/> passed back from JavaScript.</param>
        [JSInvokable]
        public void SetWatchPosition(GeolocationResult watchResult)
        {
            WatchPositionReceived?.Invoke(this, new GeolocationEventArgs
            {
                GeolocationResult = watchResult
            });
        }

        /// <inheritdoc/>
        public async Task ClearWatch(long watchId)
        {
            var module = await _jsBinder.GetModule();
            await module.InvokeVoidAsync("Geolocation.clearWatch", watchId);
        }
    }

    internal class JSBinder
    {
        internal IJSRuntime JSRuntime;
        private string _importPath;
        private Task<IJSObjectReference> _module;

        public JSBinder(IJSRuntime jsRuntime, string importPath)
        {
            JSRuntime = jsRuntime;
            _importPath = importPath;
        }

        internal async Task<IJSObjectReference> GetModule()
        {
            return await (_module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", _importPath).AsTask());
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            if (_module != null)
            {
                var module = await _module;
                await module.DisposeAsync();
            }
        }
    }
}
