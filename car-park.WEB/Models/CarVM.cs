using car_park.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace car_park.WEB.Models
{
    public class CarVM
    {
        public CarVM()
        {
            RegistrationDate = DateTime.Today;
        }

        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public int? BrandID { get; set; }

        public int? ModelID { get; set; }
        [Required]
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

        [Required]
        public int Status { get; set; }

        public List<BrandDTO> BrandList { get; set; }
        public List<ModelDTO> ModelList { get; set; }
        public List<ColorDTO> ColorList { get; set; }
        public List<GarageDTO> GarageList { get; set; }
    }
}