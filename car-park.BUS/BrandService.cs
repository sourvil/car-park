using car_park.Common;
using car_park.Contract;
using car_park.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace car_park.BUS
{
    public class BrandService : BaseService, IBrand
    {
        public ApiResult<List<BrandDTO>> Get()
        {
            var Entities = context.Brand
                .AsEnumerable()
                .Where(c => c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<BrandDTO>(c))
                .ToList();

            return new ApiResult<List<BrandDTO>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = Entities
            };

        }
    }
}
