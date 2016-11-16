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
        List<GarageDTO> Get();
        GarageDTO Get(int id);
        GarageDTO Post(GarageDTO garageDTO);
        GarageDTO Put(GarageDTO garageDTO);
        bool Delete(int id);
    }
}
