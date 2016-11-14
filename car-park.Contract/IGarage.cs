using car_park.Common;
using car_park.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Contract
{
    public interface IGarage : IBase
    {
        ApiResult<List<GarageDTO>> Get();
        ApiResult<GarageDTO> Get(int id);
        ApiResult<GarageDTO> Post(GarageDTO garageDTO);
        ApiResult<GarageDTO> Put(GarageDTO garageDTO);
        ApiResult Delete(int id);
    }
}
