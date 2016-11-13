using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using car_park.DTO;
using car_park.WEB.Models;

namespace car_park.WEB
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            base.CreateMap<GarageDTO, GarageVM>().ReverseMap();
            base.CreateMap<CarDTO, CarVM>().ReverseMap();
        }
    }
}