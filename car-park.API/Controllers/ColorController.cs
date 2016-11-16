using car_park.Common;
using car_park.Contract;
using car_park.Data.Model;
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
    public class ColorController : BaseApiController
    {
        public ApiResult<List<ColorDTO>> Get()
        {
            var Entities = kernel.Get<IColor>().Get();

            return new ApiResult<List<ColorDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = Entities
            };

        }

    }
}
