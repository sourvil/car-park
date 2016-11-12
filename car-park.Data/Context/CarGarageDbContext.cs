using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using car_park.Data.Model;

namespace car_park.Data.Context
{
    class CarGarageDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public CarGarageDbContext()
        {
            Database.Connection.ConnectionString = "server=.;database=CarGarage;Trusted_Connection=TRUE";
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Garage> Garage { get; set; }
        public DbSet<car_park.Data.Model.Model> Model { get; set; }

    }
}
