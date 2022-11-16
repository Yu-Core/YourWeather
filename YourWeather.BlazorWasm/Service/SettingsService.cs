using BlazorComponent;
using Blazored.LocalStorage;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Service;

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

        public event Action OnInit;
        private void NotifyStateChanged() => OnInit?.Invoke();

        private async void InitSettings()
        {
            var json = await LocalStorage.GetItemAsync<string>("settings");
            
            if(!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    Settings = JsonConvert.DeserializeObject<Settings>(json)!;
                }
                catch (Exception ex)
                {
                    Settings = new Settings();
                    await LocalStorage.RemoveItemAsync("settings");
                }
                
            }
            
            Settings.OnChange += SaveSetings;
            NotifyStateChanged();
        }
        
        private async void SaveSetings()
        {
            var json = JsonConvert.SerializeObject(Settings);
            await LocalStorage.RemoveItemAsync("settings");
            await LocalStorage.SetItemAsync<string>("settings", json);
        }

    }
}
