using Blazored.LocalStorage;

namespace YourWeather.Rcl.Desktop.Services
{
    public class SettingService : Rcl.Services.SettingService
    {
        private ILocalStorageService LocalStorage { get; set; }

        public SettingService(ILocalStorageService localStorageService)
        {
            LocalStorage = localStorageService;
        }

        public override async Task<bool> ContainsKey(string key)
        {
            return await LocalStorage.ContainKeyAsync(key);
        }

        public override async Task<T> Get<T>(string key, T defaultValue)
        {
            bool flag = await LocalStorage.ContainKeyAsync(key);
            if (!flag)
            {
                return defaultValue;
            }

            return await LocalStorage.GetItemAsync<T>(key);
        }

        public override async Task Save<T>(string key, T value)
        {
            await LocalStorage.SetItemAsync(key, value);
        }
    }
}
