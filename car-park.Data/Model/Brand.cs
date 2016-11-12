using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Data.Model
{
    public class Brand : BaseModel
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        public virtual List<Car> Car { get; set; }
        public virtual List<Model> Model { get; set; }
    }
}
