using BlazorComponent;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWeather.IService;
using YourWeather.Model;
using YourWeather.Model.Location;

namespace YourWeather.Razor.Shared
{
    public partial class SearchCity
    {
        [Parameter]
        public bool Value { get; set; }
        [Parameter]
        public EventCallback<bool> ValueChanged { get; set; }

        [Inject]
        private ILocationService? LocationService { get; set; }
        [Inject]
        private ISettingsService? SettingsService { get; set; }
        [Inject]
        private IThemeService ThemeService { get; set; }
        [Inject] 
        IPopupService PopupService { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        private Settings SettingsData => SettingsService.Settings;
        private bool IsDark() => ThemeService.IsDark(SettingsData.ThemeState);
        private string _search;

        private List<LocationData> LocationDatas = DefaultLocationDatas;
        private readonly static List<LocationData> DefaultLocationDatas = new List<LocationData>()
        {
            new LocationData("北京市","北京市",39.904179,116.407387),
            new LocationData( "成都市","四川省 成都市",30.572961,104.066301),
            new LocationData( "重庆市","重庆市",29.563707,106.550483),
            new LocationData("长沙市","湖南省 长沙市",28.228304,112.938882),
            new LocationData( "东莞市","广东省 东莞市",23.021016,113.751884),
            new LocationData( "佛山市","广东省 佛山市",23.021351, 113.121586),
            new LocationData( "广州市","广东省 广州市",23.130061,113.264499),
            new LocationData( "合肥市","安徽省 合肥市",31.820567,117.227267),
            new LocationData( "杭州市","浙江省 杭州市",30.246026,120.210792),
            new LocationData( "南京市","江苏省 南京市",32.059344,118.796624),
            new LocationData( "青岛市","山东省 青岛市",36.066938,120.382665),
            new LocationData( "上海市","上海市",31.230525,121.473667),
            new LocationData( "沈阳市", "辽宁省 沈阳市",41.677576,123.464675),
            new LocationData( "苏州市","江苏省 苏州市",31.299758,120.585294),
            new LocationData( "深圳市","广东省 深圳市",22.543527,114.057939),
            new LocationData( "天津市","天津市",39.085318,117.201509),
            new LocationData( "武汉市","湖北省 武汉市",30.593354,114.304569),
            new LocationData( "西安市","陕西省 西安市",34.343207,108.939645),
            new LocationData( "郑州市","河南省 郑州市",34.746303,113.625351),
        };

        protected override void OnAfterRender(bool firstRender)
        {
            if (!Value)
            {
                _search = string.Empty;
            }
        }

        protected virtual async Task HandleOnCancel(MouseEventArgs _)
        {
            await InternalValueChanged(false);

        }

        private async Task InternalValueChanged(bool value)
        {
            Value = value;

            if (ValueChanged.HasDelegate)
            {
                await ValueChanged.InvokeAsync(value);
            }
        }

        private void SearchTextChanged(string search)
        {
            _search = search;
            if (string.IsNullOrWhiteSpace(_search))
            {
                LocationDatas = DefaultLocationDatas;
            }
            else
            {
                var cities = LocationService.ChinaCities
                    .Where(p => SettingsData.LocationDatas.All(p2 => p2.Info != p.Info))
                    .Where(it => it.Info.Contains(_search))
                    .Take(50)
                    .ToList();
                if (cities.Any())
                {
                    LocationDatas = cities;
                }
                else
                {
                    LocationDatas = new List<LocationData>();
                }
            }
        }
        private async void AddLocationData(LocationData locationData)
        {
            var any = SettingsData.LocationDatas.Where(it => it.Info == locationData.Info).Any();
            if (any)
            {
                await PopupService.AlertAsync(param =>
                {
                    param.Content = "该城市已存在";
                    param.Centered = true;
                });
            }
            else
            {
                SettingsData.AddLocationData(locationData);
                await InternalValueChanged(false);
            }
            
        }
    }
}
