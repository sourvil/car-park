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
        [TestMethod]
        public void Model_Get_All()
        {
            ModelService bs = new ModelService();
            ApiResult<List<ModelDTO>> lstModel = new ApiResult<List<ModelDTO>>();

            lstModel = bs.Get();

            Assert.IsNotNull(lstModel);
            Assert.AreEqual((int)HttpStatusCode.OK, lstModel.StatusCode);


        }
    }
}
