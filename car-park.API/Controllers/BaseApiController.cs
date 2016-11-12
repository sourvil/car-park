using AutoMapper;
using car_park.API.App_Start;
using car_park.Common;
using car_park.Data.Context;
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
    //public class BaseApiController<TEntity,TDTO> : ApiController
    //
    //public class BaseApiController : ApiController
    public class BaseApiController : ApiController
    {
        public CarParkDbContext context { get; }
        public IMapper mapper { get; set; }

        public BaseApiController()
        {
            context = new CarParkDbContext();

            // AutoMapper
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig()));               
            mapper = config.CreateMapper();
        }
        
    }
}
