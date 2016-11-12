using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_park.Data.Model
{
    class Car
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CarID { get; set; }

        [Required]
        public int BrandID { get; set; }

        [Required]
        public int ModelID { get; set; }
        
        [Required]
        public int Year { get; set; }

        [Required]
        public int ColorID { get; set; }
        
        public int Mileage { get; set; }

        [Required]
        public int Engine { get; set; }
        
        public int Power { get; set; }
        
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        public int Price { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public virtual Brand Brand { get; set; }
        [Required]
        public virtual Model Model { get; set; }
        [Required]
        public virtual Color Color { get; set; }

    }
}
