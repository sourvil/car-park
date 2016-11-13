using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.DTO
{
    public class ModelDTO : BaseDTO
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        public int? BrandID { get; set; }

        public BrandDTO Brand { get; set; }
    }
}
