using AutoMapper;
using car_park.API.App_Start;
using car_park.Common;
using car_park.Data.Context;
using car_park.Data.Model;
using car_park.DTO;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace car_park.API.Controllers
{
    public class BaseApiController : ApiController
    {
        public IKernel kernel { get; }
        public IMapper mapper { get; set; }

        public BaseApiController()
        {
            if (kernel == null) {
                kernel = new StandardKernel();
                kernel.Load(new NinjectConfig());                         
            }
            if (mapper == null)
            {
                // AutoMapper
                var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig()));
                mapper = config.CreateMapper();
            }
        }
        
    }
}
