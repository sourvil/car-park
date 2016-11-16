using car_park.Common;
using car_park.Contract;
using car_park.DTO;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace car_park.API.Controllers
{
    public class BrandController : BaseApiController
    {
        public ApiResult<List<BrandDTO>> Get()
        {
            var Entities = kernel.Get<IBrand>().Get();

            return new ApiResult<List<BrandDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = Entities
            };
            
        }
    }
}
