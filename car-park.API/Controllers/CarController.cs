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
            return kernel.Get<ICar>().Get();
        }

        [HttpGet]
        public ApiResult<CarDTO> Get(int ID)
        {
            return kernel.Get<ICar>().Get(ID);
        }        

        [HttpPost]
        public ApiResult<CarDTO> Post(CarDTO carDTO)
        {
            return kernel.Get<ICar>().Post(carDTO);
        }

        [HttpPut]
        public ApiResult<CarDTO> Put(CarDTO carDTO)
        {
            return kernel.Get<ICar>().Put(carDTO);
        }
    }
}
