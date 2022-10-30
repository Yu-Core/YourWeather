using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.Model.Enum;

namespace YourWeather.Model.Item
{
    public class CodeSourceItem
    {
        public CodeSourceItem()
        {
        }
        public CodeSourceItem(string text, string value, string? icon)
        {
            Text = text;
            Value = value;
            Icon = icon;
        }
        public string? Text { get; set; }
        public string? Value { get; set; }
        public string? Icon { get; set; }
    }
}
