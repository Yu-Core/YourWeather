﻿using System.Text.Json;

namespace YourWeather.Rcl.Services
{
    public interface IStaticWebAssets
    {
        /// <summary>
        /// 读取静态web资产的json文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        Task<T> ReadJsonAsync<T>(string relativePath, bool isRcl = true, JsonSerializerOptions? jsonSerializerOptions = null);

        /// <summary>
        /// 读取静态web资产的文本内容
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        Task<string> ReadContentAsync(string relativePath, bool isRcl = true);
    }
}
