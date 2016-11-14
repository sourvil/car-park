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
    public class GarageController : BaseApiController
    {
        [HttpGet]
        public ApiResult<List<GarageDTO>> Get()
        {
            return kernel.Get<IGarage>().Get();
        }

        [HttpGet]
        public ApiResult<GarageDTO> Get(int id)
        {
            return kernel.Get<IGarage>().Get(id);
        }

        [HttpPost]
        public ApiResult<GarageDTO> Post(GarageDTO garageDTO)
        {
            return kernel.Get<IGarage>().Post(garageDTO);
        }

        [HttpPut]
        public ApiResult<GarageDTO> Put(GarageDTO garageDTO)
        {
            return kernel.Get<IGarage>().Put(garageDTO);
        }

        [HttpDelete]
        public ApiResult Delete(int id)
        {
            return kernel.Get<IGarage>().Delete(id);
        }
    }
}
