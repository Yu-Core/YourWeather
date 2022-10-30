using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Enum;

namespace YourWeather.Model.Item
{
    public class LanguageItem
    {
        public LanguageItem()
        {
        }
        public LanguageItem(string? text, string? value)
        {
            Text = text;
            Value = value;
        }

        public string? Text { get; set; }
        public string? Value { get; set; }
    }
}
