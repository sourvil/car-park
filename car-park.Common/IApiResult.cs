using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Common
{
    public interface IApiResult
    {
        int StatusCode { get; set; }
        string Message { get; set; }
    }
}
