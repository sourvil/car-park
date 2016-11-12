using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Data.Model
{
    class Brand
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BrandID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }

        public virtual List<Car> Car { get; set; }
        public virtual List<Model> Model { get; set; }
    }
}
