using car_park.BUS;
using car_park.Contract;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_park.API.App_Start
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IColor>().To<ColorService>();
            Bind<IBrand>().To<BrandService>();
            Bind<IModel>().To<ModelService>();
            Bind<IGarage>().To<GarageService>();
            Bind<ICar>().To<CarService>();
        }
    }
}