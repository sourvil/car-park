using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_park.DTO;
using System.Collections.Generic;
using car_park.Common;
using System.Net;

namespace car_park.BUS.TEST
{
    [TestClass]
    public class ModelServiceTest
    {
        // Default ID values
        private int brandID = 1;

        [TestMethod]
        public void Model_Get_All()
        {
            ModelService bs = new ModelService();
            List<ModelDTO> lstModel = new List<ModelDTO>();

            lstModel = bs.Get();

            Assert.IsNotNull(lstModel);
        }

        [TestMethod]
        public void Model_Get_ByBrandID()
        {
            ModelService bs = new ModelService();
            List<ModelDTO> lstModel = new List<ModelDTO>();

            lstModel = bs.GetByBrandId(brandID);

            Assert.IsNotNull(lstModel);
        }
    }
}
