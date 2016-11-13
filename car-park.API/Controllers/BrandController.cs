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
    public class BrandController : BaseApiController
    {
        public ApiResult<List<BrandDTO>> Get()
        {
            var Entities = context.Brand
                .AsEnumerable()
                .Where(c => c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<BrandDTO>(c))
                .ToList();

            return new ApiResult<List<BrandDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = Entities
            };

        }
    }
}
