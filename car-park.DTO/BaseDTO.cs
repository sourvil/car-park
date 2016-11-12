using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.DTO
{
    public class BaseDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
