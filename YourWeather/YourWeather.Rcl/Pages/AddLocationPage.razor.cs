using System.Text.Json;
using YourWeather.Rcl.Components;
using YourWeather.Shared;

namespace YourWeather.Rcl.Pages
{
    public partial class AddLocationPage : PageComponentBase, IDisposable
    {
        private string? _search;
        private List<Location> AllLocationDatas = new();
        private List<Location> LocationDatas = DefaultLocationDatas;
        private List<Location> SettingLocationDatas = new();
        private readonly static List<Location> DefaultLocationDatas = new()
        {
            new Location("北京市","北京市",39.904179,116.407387),
            new Location( "成都市","四川省 成都市",30.572961,104.066301),
            new Location( "重庆市","重庆市",29.563707,106.550483),
            new Location("长沙市","湖南省 长沙市",28.228304,112.938882),
            new Location( "东莞市","广东省 东莞市",23.021016,113.751884),
            new Location( "佛山市","广东省 佛山市",23.021351, 113.121586),
            new Location( "广州市","广东省 广州市",23.130061,113.264499),
            new Location( "合肥市","安徽省 合肥市",31.820567,117.227267),
            new Location( "杭州市","浙江省 杭州市",30.246026,120.210792),
            new Location( "南京市","江苏省 南京市",32.059344,118.796624),
            new Location( "青岛市","山东省 青岛市",36.066938,120.382665),
            new Location( "上海市","上海市",31.230525,121.473667),
            new Location( "沈阳市", "辽宁省 沈阳市",41.677576,123.464675),
            new Location( "苏州市","江苏省 苏州市",31.299758,120.585294),
            new Location( "深圳市","广东省 深圳市",22.543527,114.057939),
            new Location( "天津市","天津市",39.085318,117.201509),
            new Location( "武汉市","湖北省 武汉市",30.593354,114.304569),
            new Location( "西安市","陕西省 西安市",34.343207,108.939645),
            new Location( "郑州市","河南省 郑州市",34.746303,113.625351),
        };

        public void Dispose()
        {
            MainLayout.ShowBack(false, "");
            GC.SuppressFinalize(this);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Title = "添加城市";
            MainLayout.ShowBack(true, "location");
            AllLocationDatas = await LocationService.GetAllLocations();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await LoadSettings();
            }
        }

        private async Task LoadSettings()
        {
            var locations = await SettingsService.Get<string>(SettingType.Locations);
            if (!string.IsNullOrEmpty(locations))
            {
                SettingLocationDatas = JsonSerializer.Deserialize<List<Location>>(locations) ?? new();
            }
        }

        private async Task AddLocation(Location location)
        {
            var any = SettingLocationDatas.Any(it => it.Info == location.Info);
            if (any)
            {
                await PopupService.EnqueueSnackbarAsync(new()
                {
                    Content = "该城市已存在",
                    Type = BlazorComponent.AlertTypes.Info
                });
            }
            else
            {
                SettingLocationDatas.Add(location);
                var locations = JsonSerializer.Serialize(SettingLocationDatas);
                await SettingsService.Save(SettingType.Locations, locations);
            }
            
            Navigation.NavigateTo("location");
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
                var cities = AllLocationDatas
                    .Where(p => SettingLocationDatas.All(p2 => p2.Info != p.Info))
                    .Where(it => (it.Info ?? "").Contains(_search))
                    .ToList();
                if (cities.Any())
                {
                    LocationDatas = cities;
                }
                else
                {
                    LocationDatas = new();
                }
            }
        }
    }
}
