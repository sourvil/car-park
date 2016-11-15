using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_park.API.Controllers;
using car_park.Common;
using System.Collections.Generic;
using car_park.DTO;
using System.Net;

namespace car_park.API.TEST
{
    [TestClass]
    public class ColorControllerTest
    {
        [TestMethod]
        public void Color_Get_All()
        {
            ColorController cc = new ColorController();
            ApiResult<List<ColorDTO>> lstColor = new ApiResult<List<ColorDTO>>();

            lstColor = cc.Get();

            Assert.IsNotNull(lstColor);
            Assert.AreEqual((int)HttpStatusCode.OK, lstColor.StatusCode);


        }
    }
}
