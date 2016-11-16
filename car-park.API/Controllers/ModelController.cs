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
            var Entities = kernel.Get<IModel>().Get();

            return new ApiResult<List<ModelDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = Entities
            };
        }

        public ApiResult<List<ModelDTO>> GetByBrandId(int id)
        {
            var Entities = kernel.Get<IModel>().GetByBrandId(id);

            return new ApiResult<List<ModelDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = Entities
            };
        }
    }
}
