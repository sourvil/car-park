﻿using car_park.Common;
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
        ApiResult<List<CarDTO>> Get();
        ApiResult<CarDTO> Get(int ID);
        ApiResult<CarDTO> Post(CarDTO carDTO);
        ApiResult<CarDTO> Put(CarDTO carDTO);
    }
}