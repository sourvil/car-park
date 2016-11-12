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
    public class GarageController : BaseApiController
    {
        [HttpGet]
        //[Route("api/garages")]
        public ApiResult<List<GarageDTO>> Get()
        {
            var entities = context.Garage
                .AsEnumerable()
                .Where(c => c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<GarageDTO>(c))
                .ToList();

            return new ApiResult<List<GarageDTO>>
            {
                StatusCode = 200,
                Data = entities
            };

        }

        [HttpGet]
        public ApiResult<GarageDTO> Get(int ID)
        {
            var entity = context.Garage
                .AsEnumerable()
                .Where(c => c.ID == ID && c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<GarageDTO>(c))
                .FirstOrDefault();

            return new ApiResult<GarageDTO>
            {
                StatusCode = 200,
                Data = entity
            };

        }

        [HttpPost]
        [Route("api/garage/edit")]
        public ApiResult<GarageDTO> Edit(GarageDTO garageDTO)
        {
            var entity = mapper.Map<Garage>(garageDTO);
            // Update
            if (garageDTO.ID > 0)
            {
                if (entity == null)
                    return new ApiResult<GarageDTO> { StatusCode = 404, Message = "Garage Not Found" };
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            // Insert
            else
            {
                context.Garage.Add(entity);
            }
            context.SaveChanges();

            return new ApiResult<GarageDTO> { StatusCode = 200, Data = mapper.Map<GarageDTO>(entity) };
          
        }
    }
}
