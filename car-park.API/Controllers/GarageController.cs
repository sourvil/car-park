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
            var entities = kernel.Get<IGarage>().Get();

            return new ApiResult<List<GarageDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = entities
            };
        }

        [HttpGet]
        public ApiResult<GarageDTO> Get(int id)
        {
            var entity = kernel.Get<IGarage>().Get(id);

            return new ApiResult<GarageDTO>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = entity
            };
        }

        [HttpPost]
        public ApiResult<GarageDTO> Post(GarageDTO garageDTO)
        {
            var returnDTO = kernel.Get<IGarage>().Post(garageDTO);

            return new ApiResult<GarageDTO> { StatusCode = (int)HttpStatusCode.OK, Data = returnDTO, Message = "Garage is Inserted" };
        }

        [HttpPut]
        public ApiResult<GarageDTO> Put(GarageDTO garageDTO)
        {
            var returnDTO = kernel.Get<IGarage>().Put(garageDTO);

            if (returnDTO == null)
                return new ApiResult<GarageDTO> { StatusCode = (int)HttpStatusCode.NotFound, Message = "Garage Not Found" };

            return new ApiResult<GarageDTO> { StatusCode = (int)HttpStatusCode.OK, Data = returnDTO, Message = "Garage is Updated" };
        }

        [HttpDelete]
        public ApiResult Delete(int id)
        {
            var result = kernel.Get<IGarage>().Delete(id);

            if(result)
                return new ApiResult { StatusCode = (int)HttpStatusCode.OK, Message = "Garage is Deleted" };
            else
                return new ApiResult { StatusCode = (int)HttpStatusCode.NotAcceptable, Message = "Garage is Not Deleted!" };
        }
    }
}
