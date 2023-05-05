namespace YourWeather.Shared
{
    public class CodeSource
    {
        public CodeSource(string name,string icon,string url) 
        { 
            Name = name;
            Icon = icon;
            Url = url;
        }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Url { get;set; }
    }
}
