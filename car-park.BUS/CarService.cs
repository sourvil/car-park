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
        public List<CarDTO> Get()
        {
            var entities = context.Car
                .AsEnumerable()
                .Where(c => c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<CarDTO>(c))
                .ToList();

            return entities;

        }
        
        public CarDTO Get(int ID)
        {
            var entity = context.Car
                .AsEnumerable()
                .Where(c => c.ID == ID && c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<CarDTO>(c))
                .FirstOrDefault();

            return entity;
        }
        
        public CarDTO Post(CarDTO carDTO)
        {
            var entity = mapper.Map<Car>(carDTO);
            entity.Status = (int)Common.Enumaration.Status.Active;

            if (!CheckGarageAvailability(carDTO))
                return null;

            context.Car.Add(entity);
            context.SaveChanges();

            return mapper.Map<CarDTO>(entity);
        }
        
        public CarDTO Put(CarDTO carDTO)
        {
            var entity = mapper.Map<Car>(carDTO);

            entity.Status = (int)Common.Enumaration.Status.Active;

            if (entity == null)
                return null;
            else if (!CheckGarageAvailability(carDTO))
                return new CarDTO();
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();           

            return mapper.Map<CarDTO>(entity);
        }

        public bool CheckGarageAvailability(CarDTO carDTO)
        {
            var entity = mapper.Map<Car>(carDTO);

            int currentCarCount = context.Car
                .Where(c => c.GarageID == entity.GarageID && c.Status != (int)Enumaration.Status.Deleted && c.ID != entity.ID)
                .Count();

            int garageCarCapacity = context.Garage
                .Where(g => g.ID == entity.GarageID)
                .FirstOrDefault()
                .MaxCar;

            if (currentCarCount >= garageCarCapacity)
                return false;
            else
                return true;
        }
    }
}
