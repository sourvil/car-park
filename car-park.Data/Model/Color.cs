using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Data.Model
{
    class Color
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ColorID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }

        public virtual List<Car> Car { get; set; }
    }
}
