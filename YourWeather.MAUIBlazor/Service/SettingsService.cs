using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Service;

namespace YourWeather.MAUIBlazor.Service
{
    public class SettingsService : ISettingsService
    {
        readonly static string dataPath = "Config";
        readonly static string fileName = "settings.json";
        readonly static string documentsPath = FileSystem.Current.AppDataDirectory; // Documents folder
        readonly static string path_settings = Path.Combine(documentsPath, dataPath, fileName);
        readonly static string path_Config = Path.Combine(documentsPath, dataPath);

        public SettingsService()
        {
            InitSettings();
        }

        public Settings Settings { get;private set; } = new Settings();

        public event Action OnInit;
        private void NotifyStateChanged() => OnInit?.Invoke();

        private void InitSettings()
        {
            string json = string.Empty;
            if (File.Exists(path_settings))
            {
                json = File.ReadAllText(path_settings);
                
            }
            if(!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    Settings = JsonConvert.DeserializeObject<Settings>(json);
                }
                catch (Exception ex)
                {
                    Settings = new();
                }
                
            }
            
            Settings.OnChanged += SaveSetings;
            NotifyStateChanged();
        }

        private void SaveSetings()
        {
            if (!Directory.Exists(path_Config))
                Directory.CreateDirectory(path_Config);
            var json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            File.WriteAllText(path_settings, json);
        }

    }
}
