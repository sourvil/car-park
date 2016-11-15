namespace car_park.Data.Migrations
{
    using Common;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<car_park.Data.Context.CarParkDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(car_park.Data.Context.CarParkDbContext context)
        {   
            // Initial Records

            // Color
            context.Color.AddOrUpdate(
                c => new { c.Name, c.Status },
                new Model.Color { Name = "White", Status = (int)Enumaration.Status.Active },
                new Model.Color { Name = "Black", Status = (int)Enumaration.Status.Active },
                new Model.Color { Name = "Gray", Status = (int)Enumaration.Status.Active },
                new Model.Color { Name = "Blue", Status = (int)Enumaration.Status.Active },
                new Model.Color { Name = "Yellow", Status = (int)Enumaration.Status.Active },
                new Model.Color { Name = "Red", Status = (int)Enumaration.Status.Active },
                new Model.Color { Name = "Green", Status = (int)Enumaration.Status.Active }
                );

            // Brand
            context.Brand.AddOrUpdate(
                b => new {b.Name, b.Status},
                new Model.Brand { Name = "BMW", Status = (int)Enumaration.Status.Active},
                new Model.Brand { Name = "TOYOTA", Status = (int)Enumaration.Status.Active },
                new Model.Brand { Name = "AUDI", Status = (int)Enumaration.Status.Active }
                );

            // Model
            context.Model.AddOrUpdate(
                m => new { m.Name, m.Status, m.BrandID },
                new Model.Model { Name = "1.16", Status = (int)Enumaration.Status.Active, BrandID = 1 },
                new Model.Model { Name = "3.20", Status = (int)Enumaration.Status.Active, BrandID = 1 },
                new Model.Model { Name = "5.25", Status = (int)Enumaration.Status.Active, BrandID = 1 },

                new Model.Model { Name = "Corolla", Status = (int)Enumaration.Status.Active, BrandID = 2 },
                new Model.Model { Name = "Auris", Status = (int)Enumaration.Status.Active, BrandID = 2 },
                new Model.Model { Name = "Yaris", Status = (int)Enumaration.Status.Active, BrandID = 2 },

                new Model.Model { Name = "A1", Status = (int)Enumaration.Status.Active, BrandID = 3 },
                new Model.Model { Name = "A3", Status = (int)Enumaration.Status.Active, BrandID = 3 },
                new Model.Model { Name = "A5", Status = (int)Enumaration.Status.Active, BrandID = 3 }
                );

            // Garage
            context.Garage.AddOrUpdate(
                g => new { g.Name, g.Address, g.Status, g.MaxCar },
                new Model.Garage { Name = "TEST GARAGE", Address = "ISTANBUL", Status = (int)Enumaration.Status.Active, MaxCar = 10 },
                new Model.Garage { Name = "PILOT GARAGE", Address = "BARCELONA", Status = (int)Enumaration.Status.Active, MaxCar = 10}
                );
            context.SaveChanges();

            // Car
            context.Car.AddOrUpdate(
                c => new { c.Name, c.Year, c.GarageID, c.RegistrationDate, c.Status },
                new Model.Car { Name = "TEST CAR", Year = 2015, GarageID = 1, RegistrationDate = DateTime.Today, Status = (int)Enumaration.Status.Active },
                new Model.Car { Name = "PILOT CAR", Year = 2016, GarageID = 2, RegistrationDate = DateTime.Today, Status = (int)Enumaration.Status.Active }
                );

        }
    }
}
