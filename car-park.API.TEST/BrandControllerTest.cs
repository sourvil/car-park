using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_park.API.Controllers;
using car_park.DTO;
using System.Collections.Generic;
using car_park.Common;
using System.Net;

namespace car_park.API.TEST
{
    [TestClass]
    public class BrandControllerTest
    {
        [TestMethod]
        public void BrandController_Get()
        {
            BrandController bc = new BrandController();            
            ApiResult<List<BrandDTO>> lstBrand = new ApiResult<List<BrandDTO>>();

            lstBrand = bc.Get();

            Assert.IsNotNull(lstBrand);

            Assert.AreEqual((int)HttpStatusCode.OK, lstBrand.StatusCode);

        }
    }
}
