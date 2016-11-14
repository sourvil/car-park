using AutoMapper;
using car_park.BUS.Config;
using car_park.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.BUS
{
    public class BaseService
    {
        public CarParkDbContext context { get; }
        public IMapper mapper { get; set; }

        public BaseService()
        {
            if (context == null)
                context = new CarParkDbContext();

            if (mapper == null)
            {
                // AutoMapper
                var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig()));
                mapper = config.CreateMapper();
            }
        }
    }
}
