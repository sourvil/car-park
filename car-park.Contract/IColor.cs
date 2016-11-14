﻿using car_park.Common;
using car_park.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Contract
{
    public interface IColor : IBase
    {
        ApiResult<List<ColorDTO>> Get();
    }
}