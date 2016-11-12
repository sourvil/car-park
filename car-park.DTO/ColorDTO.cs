using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.DTO
{
    public class ColorDTO : BaseDTO
    {

        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
