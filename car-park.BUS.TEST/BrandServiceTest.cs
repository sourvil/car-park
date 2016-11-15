using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_park.DTO;
using car_park.Common;
using System.Collections.Generic;
using System.Net;

namespace car_park.BUS.TEST
{
    [TestClass]
    public class BrandServiceTest
    {
        [TestMethod]
        public void Brand_Get_All()
        {
            BrandService bs = new BrandService();
            ApiResult<List<BrandDTO>> lstBrand = new ApiResult<List<BrandDTO>>();

            lstBrand = bs.Get();

            Assert.IsNotNull(lstBrand);

            Assert.AreEqual((int)HttpStatusCode.OK, lstBrand.StatusCode);


        }
    }
}
