using car_park.Common;
using car_park.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Contract
{
    public interface ICar : IBase
    {
        List<CarDTO> Get();
        CarDTO Get(int ID);
        CarDTO Post(CarDTO carDTO);
        CarDTO Put(CarDTO carDTO);
    }
}
