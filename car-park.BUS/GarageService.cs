using car_park.Common;
using car_park.Contract;
using car_park.Data.Model;
using car_park.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace car_park.BUS
{
    public class GarageService : BaseService, IGarage
    {
        public ApiResult<List<GarageDTO>> Get()
        {            
            var entities = context.Garage
                .AsEnumerable()
                .Where(g => g.Status != (int)Enumaration.Status.Deleted)
                .ToList()
                .Select(g => new GarageDTO
                {
                    Name = g.Name,
                    Address = g.Address,
                    Email = g.Email,
                    ID = g.ID,
                    MaxCar = g.MaxCar,
                    PhoneNumber = g.PhoneNumber,
                    Status = g.Status,
                    CarsInStock = g.Car.Count()
                })
                .ToList();



            return new ApiResult<List<GarageDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = entities
            };

        }
        
        public ApiResult<GarageDTO> Get(int id)
        {
            var entity = context.Garage
                .AsEnumerable()
                .Where(g => g.ID == id && g.Status != (int)Enumaration.Status.Deleted)
                .Select(g => new GarageDTO
                {
                    Name = g.Name,
                    Address = g.Address,
                    Email = g.Email,
                    ID = g.ID,
                    MaxCar = g.MaxCar,
                    PhoneNumber = g.PhoneNumber,
                    Status = g.Status,
                    CarsInStock = g.Car.Count()
                })
                .FirstOrDefault();

            entity.CarsInGarage = context.Car
                .AsEnumerable()
                .Where(c => c.GarageID == entity.ID && c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<CarDTO>(c))
                .ToList();

            return new ApiResult<GarageDTO>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = entity
            };
        }
        
        public ApiResult<GarageDTO> Post(GarageDTO garageDTO)
        {
            var entity = mapper.Map<Garage>(garageDTO);
            entity.Status = (int)Common.Enumaration.Status.Active;

            context.Garage.Add(entity);
            context.SaveChanges();

            return new ApiResult<GarageDTO> { StatusCode = (int)HttpStatusCode.OK, Data = mapper.Map<GarageDTO>(entity), Message = "Garage is Inserted" };
        }
        
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
        
        public ApiResult Delete(int id)
        {
            var entity = context.Garage
                .Where(g => g.ID == id)
                .FirstOrDefault();
            entity.Status = (int)Enumaration.Status.Deleted;
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return new ApiResult { StatusCode = (int)HttpStatusCode.OK, Message = "Garage is Deleted" };
        }
    }
}
