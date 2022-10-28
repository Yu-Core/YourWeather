using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using YourWeather.IService;
using YourWeather.Model;

namespace YourWeather.BlazorWasm.Service
{
    public class SettingsService : ISettingsService
    {
        [Inject]
        private ILocalStorageService LocalStorage { get; set; }
        public SettingsService(ILocalStorageService localStorage)
        {
            LocalStorage = localStorage;
            InitSettings();
        }
        public Settings Settings { get; private set; } = new Settings();

        
        private async void InitSettings()
        {
            var json = await LocalStorage.GetItemAsync<string>("settings");
            
            if(json != null)
            {
                Settings = JsonConvert.DeserializeObject<Settings>(json)!;
            }
            
            Settings.OnChange += SaveSetings;
        }

        private async void SaveSetings()
        {
            var json = JsonConvert.SerializeObject(Settings);
            await LocalStorage.RemoveItemAsync("settings");
            await LocalStorage.SetItemAsync<string>("settings", json);
        }
    }
}
