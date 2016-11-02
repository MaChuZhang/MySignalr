using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MySignalr.DAL
{
    /// <summary>
    /// 仅 Api v2 中使用，注意阅读 Api v2规范
    /// </summary>
    public class ApiResult<T> : ApiResult
    {
        public new static ApiResult<T> Error(string message)
        {
            return new ApiResult<T>
            {
                Code = 1,
                Message = message,
            };
        }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
    /// <summary>
    /// 仅 Api v2 中使用，注意阅读 Api v2规范
    /// </summary>
    public class ApiResult
    {
        public static ApiResult Error(string message)
        {
            return new ApiResult
            {
                Code = 1,
                Message = message,
            };
        }

        public static ApiResult<T> Ok<T>(T data)
        {
            return new ApiResult<T>()
            {
                Code = 0,
                Message = "",
                Data = data
            };
        }
        /// <summary>
        /// 0 是 正常 1 是有错误
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => Code == 0;
    }
}
