using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Common
{
    /// <summary>
    /// Web Api Response Message Interface
    /// </summary>
    public class ApiResult : IApiResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    /// <summary>
    /// Web Api Response Message Interface as a generic type
    /// </summary>
    public class ApiResult<T> : IApiResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
