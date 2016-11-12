using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Data.Model
{
    public class Color : BaseModel
    {

        [Required, StringLength(50)]
        public string Name { get; set; }
        

        public virtual List<Car> Car { get; set; }
    }
}
