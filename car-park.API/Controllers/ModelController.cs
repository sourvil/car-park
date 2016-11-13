using car_park.Common;
using car_park.DTO;
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
            var Entities = context.Model
                .AsEnumerable()
                .Where(c => c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<ModelDTO>(c))
                .ToList();

            return new ApiResult<List<ModelDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = Entities
            };

        }
    }
}
