using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.MAUIBlazor.Service
{
    public static class I18nService
    {
        public static Dictionary<string, string> I18nJson => new Dictionary<string, string>
        {
            {"zh-CN",zh_CN},
            {"en-US",en_US},
        };
        private static readonly string zh_CN =
        @"{
            ""$DefaultCulture"": ""true"",
            ""Data"": ""首页""
        }";
        private static readonly string en_US =
        @"{
            ""Data"": ""Data""
        }";
    }
}
