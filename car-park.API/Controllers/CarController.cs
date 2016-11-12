using car_park.Common;
using car_park.Data.Model;
using car_park.DTO;
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
        //[Route("api/Cars")]
        public ApiResult<List<CarDTO>> Get()
        {
            var entities = context.Car
                .AsEnumerable()
                .Where(c => c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<CarDTO>(c))
                .ToList();

            return new ApiResult<List<CarDTO>>
            {
                StatusCode = 200,
                Data = entities
            };

        }

        [HttpGet]
        public ApiResult<CarDTO> Get(int ID)
        {
            var entity = context.Car
                .AsEnumerable()
                .Where(c => c.ID == ID && c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<CarDTO>(c))
                .FirstOrDefault();

            return new ApiResult<CarDTO>
            {
                StatusCode = 200,
                Data = entity
            };

        }

        [HttpPost]
        [Route("api/car/edit")]
        public ApiResult<CarDTO> Edit(CarDTO CarDTO)
        {
            var entity = mapper.Map<Car>(CarDTO);
            // Update
            if (CarDTO.ID > 0)
            {
                if (entity == null)
                    return new ApiResult<CarDTO> { StatusCode = 404, Message = "Car Not Found" };
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            // Insert
            else
            {
                context.Car.Add(entity);
            }
            context.SaveChanges();

            return new ApiResult<CarDTO> { StatusCode = 200, Data = mapper.Map<CarDTO>(entity) };

        }
    }
}
