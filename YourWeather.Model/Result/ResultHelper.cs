using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWeather.Model.Result
{
    public static class ResultHelper
    {
        public static Result<T> Success<T>(T data)
        {
            return new Result<T>()
            {
                Data = data
            };
        }
        public static Result<T> Error<T>(string msg)
        {
            return new Result<T>()
            {
                Message = msg
            };
        }
    }
}
