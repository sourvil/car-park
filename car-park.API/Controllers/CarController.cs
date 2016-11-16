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
    public class CarController : BaseApiController
    {
        [HttpGet]
        public ApiResult<List<CarDTO>> Get()
        {
            var entities =  kernel.Get<ICar>().Get();

            return new ApiResult<List<CarDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = entities
            };
        }

        [HttpGet]
        public ApiResult<CarDTO> Get(int ID)
        {
            var entity = kernel.Get<ICar>().Get(ID);
            return new ApiResult<CarDTO>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = entity
            };
        }        

        [HttpPost]
        public ApiResult<CarDTO> Post(CarDTO carDTO)
        {
            var returnDTO = kernel.Get<ICar>().Post(carDTO);

            if (returnDTO == null)
                return new ApiResult<CarDTO> { StatusCode = (int)HttpStatusCode.NotAcceptable, Message = "Max Car on the Garage!" };

            return new ApiResult<CarDTO> { StatusCode = (int)HttpStatusCode.OK, Data = returnDTO, Message = "Car is Inserted" };
        }

        [HttpPut]
        public ApiResult<CarDTO> Put(CarDTO carDTO)
        {
            var returnDTO = kernel.Get<ICar>().Put(carDTO);

            if (returnDTO == null)
                return new ApiResult<CarDTO> { StatusCode = (int)HttpStatusCode.NotFound, Message = "Car Not Found" };
            else if (returnDTO.ID <= 0)
                return new ApiResult<CarDTO> { StatusCode = (int)HttpStatusCode.NotAcceptable, Message = "Max Car on the Garage!" };


            return new ApiResult<CarDTO> { StatusCode = (int)HttpStatusCode.OK, Data = returnDTO, Message = "Car is Updated" };
        }
    }
}
