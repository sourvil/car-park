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
                StatusCode = (int)HttpStatusCode.OK,
                Data = entities
            };

        }

        [HttpGet]
        public ApiResult<GarageDTO> Get(int id)
        {
            var entity = context.Garage
                .AsEnumerable()
                .Where(c => c.ID == id && c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<GarageDTO>(c))
                .FirstOrDefault();

            return new ApiResult<GarageDTO>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = entity
            };

        }

        [HttpPost]
        public ApiResult<GarageDTO> Post(GarageDTO garageDTO)
        {
            var entity = mapper.Map<Garage>(garageDTO);
            entity.Status = (int)Common.Enumaration.Status.Active;

            context.Garage.Add(entity);
            context.SaveChanges();

            return new ApiResult<GarageDTO> { StatusCode = (int)HttpStatusCode.OK, Data = mapper.Map<GarageDTO>(entity), Message = "Garage is Inserted" };
        }

        [HttpPut]
        public ApiResult<GarageDTO> Put(GarageDTO garageDTO)
        {
            var entity = mapper.Map<Garage>(garageDTO);
            entity.Status = (int)Common.Enumaration.Status.Active;

            if (entity == null)
                return new ApiResult<GarageDTO> { StatusCode = (int)HttpStatusCode.NotFound, Message = "Garage Not Found" };
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return new ApiResult<GarageDTO> { StatusCode = (int)HttpStatusCode.OK, Data = mapper.Map<GarageDTO>(entity), Message = "Garage is Updated" };
        }

        [HttpDelete]
        public ApiResult Delete(int id)
        {
            var entity = context.Garage
                .Where(g => g.ID == id)
                .FirstOrDefault();
            entity.Status = (int)Enumaration.Status.Deleted;
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return new ApiResult { StatusCode = (int)HttpStatusCode.OK, Message= "Garage is Deleted" };
        }
    }
}
