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
    public class ModelController : BaseApiController
    {
        public ApiResult<List<ModelDTO>> Get()
        {
            return kernel.Get<IModel>().Get();

        }
    }
}
