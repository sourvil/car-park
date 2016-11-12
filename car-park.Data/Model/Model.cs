using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Data.Model
{
    public class Model
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int BrandID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }
        
        public virtual Brand Brand { get; set; }
        public virtual List<Car> Car { get; set; }
    }
}
