using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_park.Common;
using car_park.DTO;
using System.Collections.Generic;
using System.Net;

namespace car_park.BUS.TEST
{
    [TestClass]
    public class ColorServiceTest
    {
        [TestMethod]
        public void Color_Get_All()
        {
            ColorService bs = new ColorService();
            List<ColorDTO> lstColor = new List<ColorDTO>();

            lstColor = bs.Get();

            Assert.IsNotNull(lstColor);


        }
    }
}
