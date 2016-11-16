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
    public class ColorService : BaseService,IColor
    {
        public List<ColorDTO> Get()
        {
            var Entities = context.Color
                .AsEnumerable()
                .Where(c => c.Status != (int)Enumaration.Status.Deleted)
                .Select(c => mapper.Map<ColorDTO>(c))
                .ToList();

            return Entities;

        }
    }
}
