using YourWeather.Shared;

namespace YourWeather.Rcl.Services
{
    public class SettingService : ISettingsService
    {
        protected readonly Dictionary<SettingType, dynamic> Settings = new()
        {
            {SettingType.Language,"zh-CN" },
            {SettingType.Theme,(int)ThemeType.Light }
        };

        public virtual Task<bool> ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(SettingType type)
        {
            var defaultValue = Settings[type];
            return Get(type, defaultValue);
        }

        public Task<T> Get<T>(SettingType type, T defaultValue)
        {
            var key = Enum.GetName(typeof(SettingType), type);
            return Get(key!, defaultValue);
        }

        public virtual Task<T> Get<T>(string key, T defaultValue)
        {
            throw new NotImplementedException();
        }

        public Task Save<T>(SettingType type, T value)
        {
            var key = Enum.GetName(typeof(SettingType), type);
            return Save(key!, value);
        }

        public virtual Task Save<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}
