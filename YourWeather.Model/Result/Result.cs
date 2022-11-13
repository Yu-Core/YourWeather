using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Result
{
    public class Result<T>
    {
        public bool IsSuccess => Data != null;
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
