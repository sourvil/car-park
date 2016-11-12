using AutoMapper;
using car_park.Common;
using car_park.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace car_park.API.Controllers
{
    //public class BaseApiController<TEntity,TDTO> : ApiController
    public class BaseApiController : ApiController
    {
        public CarParkDbContext Context { get; }
        public IMapper Mapper { get; set; }

        public BaseApiController()
        {
            Context = new CarParkDbContext();
        }

        //[HttpGet()]
        //public virtual ApiResult<TDTO> Get(Guid id)
        //{
        //    var entities = Context.Set<TEntity>()
        //        .Where(e => e.)   
        //    //var entities = Context.Set<TEntity>()
        //    //    .Where(x => x.Status != State.Deleted)
        //    //    .Select(x => Mapper.Map<TDTO>(x))
        //    //    .ToList();

        //    //return new ApiResult<List<TDTO>> { StatusCode = 200, Data = entities };

        //    return new ApiResult<TDTO>();
        //}
    }
}
