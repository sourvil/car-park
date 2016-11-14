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
    public class CarService : BaseService, ICar
    {
        public ApiResult<List<CarDTO>> Get()
        {
            var entities = context.Car
                .AsEnumerable()
                .Where(c => c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<CarDTO>(c))
                .ToList();

            return new ApiResult<List<CarDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = entities
            };

        }
        
        public ApiResult<CarDTO> Get(int ID)
        {
            var entity = context.Car
                .AsEnumerable()
                .Where(c => c.ID == ID && c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<CarDTO>(c))
                .FirstOrDefault();

            return new ApiResult<CarDTO>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = entity
            };

        }
        
        public ApiResult<CarDTO> Post(CarDTO carDTO)
        {
            var entity = mapper.Map<Car>(carDTO);
            entity.Status = (int)Common.Enumaration.Status.Active;

            context.Car.Add(entity);
            context.SaveChanges();

            return new ApiResult<CarDTO> { StatusCode = (int)HttpStatusCode.OK, Data = mapper.Map<CarDTO>(entity), Message = "Car is Inserted" };
        }
        
        public ApiResult<CarDTO> Put(CarDTO carDTO)
        {
            var entity = mapper.Map<Car>(carDTO);

            entity.Status = (int)Common.Enumaration.Status.Active;

            if (entity == null)
                return new ApiResult<CarDTO> { StatusCode = (int)HttpStatusCode.NotFound, Message = "Car Not Found" };
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();           

            return new ApiResult<CarDTO> { StatusCode = (int)HttpStatusCode.OK, Data = mapper.Map<CarDTO>(entity), Message = "Car is Updated" };
        }
    }
}
