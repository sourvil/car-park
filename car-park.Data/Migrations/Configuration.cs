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
            //  This method will be called after migrating to the latest version.

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
        }
    }
}
