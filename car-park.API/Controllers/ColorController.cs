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
    public class ColorController : BaseApiController
    {
        public ApiResult<List<ColorDTO>> Get()
        {
            var Entities = Context.Color
                .Where(c => c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => Mapper.Map<ColorDTO>(c))
                .ToList();

            return new ApiResult<List<ColorDTO>>
            {
                StatusCode = 200,
                Data = Entities
            };

        }

        //public ApiResult<List<Data.Model.Color>> Get()
        //{
        //    var Entities = Context.Color
        //        .Where(c => c.Status != (int)Enumaration.Status.Deleted)
        //        .ToList();

        //    return new ApiResult<List<Data.Model.Color>>
        //    {
        //        StatusCode = 200,
        //        Data = Entities
        //    };

        //}
    }
}
