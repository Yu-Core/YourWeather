using BlazorComponent.I18n;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace YourWeather.MAUIBlazor.Extend
{
    public static class I18nExtend
    {
        public static IBlazorComponentBuilder AddI18nForMauiBlazor(this IBlazorComponentBuilder builder, Dictionary<string, string> I18nJson)
        {
            List<(string culture, Dictionary<string, string>)> locales = new List<(string, Dictionary<string, string>)>();
            foreach (var item in I18nJson)
            {
                Dictionary<string, string> map = JsonSerializer.Deserialize<Dictionary<string, string>>(item.Value) ?? throw new Exception("Failed to read supportedCultures json file data!"); ;
                locales.Add((item.Key, map));
            }

            (string cultureName, Dictionary<string, string> map)[] localesArray = locales.ToArray();
            I18nServiceCollectionExtensions.AddI18n(builder, localesArray);
            return builder;
        }
    }
}
