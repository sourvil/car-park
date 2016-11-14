using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.DTO
{
    public class CarDTO : BaseDTO
    {
        [Required]
        public string Name { get; set; }

        public int? BrandID { get; set; }

        public int? ModelID { get; set; }
        //[Required]
        public int? GarageID { get; set; }

        [Required]
        public int Year { get; set; }


        public int? ColorID { get; set; }

        public int? Mileage { get; set; }


        public int? Engine { get; set; }

        public int? Power { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        public int? Price { get; set; }

    }
}
