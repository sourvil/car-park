using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_park.API.Controllers;
using System.Collections.Generic;
using car_park.Common;
using car_park.DTO;
using System.Net;

namespace car_park.API.TEST
{
    [TestClass]
    public class ModelControllerTest
    {
        [TestMethod]
        public void ModelController_Get_All()
        {
            ModelController mc = new ModelController();
            ApiResult<List<ModelDTO>> lstModel = new ApiResult<List<ModelDTO>>();

            lstModel = mc.Get();

            Assert.IsNotNull(lstModel);
            Assert.AreEqual((int)HttpStatusCode.OK, lstModel.StatusCode);


        }
    }
}
