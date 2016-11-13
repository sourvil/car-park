using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using car_park.Data.Model;
using car_park.DTO;

namespace car_park.API.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            base.CreateMap<Color, ColorDTO>().ReverseMap();
            base.CreateMap<Brand, BrandDTO>().ReverseMap();
            base.CreateMap<Model, ModelDTO>().ReverseMap();
            base.CreateMap<Car, CarDTO>().ReverseMap();
            base.CreateMap<Garage, GarageDTO>().ReverseMap();
        }
    }
}