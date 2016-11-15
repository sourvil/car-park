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
    public class GarageControllerTest
    {
        // Default ID values
        private int garageID = 1, carID = 1;

        // Prepare default records
        public GarageControllerTest()
        {
            // Activate Default Car if deleted
            CarController cc = new CarController();
            CarDTO carDTO = new CarDTO();
            carDTO.ID = carID;  // Default CarID
            carDTO.Name = "CAR_TEST_NAME";
            carDTO.Year = DateTime.Today.Year;
            carDTO.RegistrationDate = DateTime.Today;
            carDTO.GarageID = garageID;
            carDTO.Status = (int)Enumaration.Status.Active;
            ApiResult<CarDTO> result = cc.Put(carDTO);


            // Activate Default Garage if deleted
            GarageController gc = new GarageController();
            ApiResult<GarageDTO> resultGarage = gc.Put(new GarageDTO()
            {
                ID = garageID, // Default Garage ID
                Name = "TEST_GARAGE_PUT" + DateTime.Now.ToString(),
                Address = "TEST_UPDATED_ADDRESS",
                Status = (int)Enumaration.Status.Active,
                MaxCar = 100
            });
        }        

        [TestMethod]
        public void GarageController_Get_All()
        {
            GarageController gc = new GarageController();
            ApiResult<List<GarageDTO>> lstGarage = new ApiResult<List<GarageDTO>>();

            lstGarage = gc.Get();

            Assert.IsNotNull(lstGarage);
            Assert.AreEqual((int)HttpStatusCode.OK, lstGarage.StatusCode);
        }

        [TestMethod]
        public void GarageController_Get_ById()
        {
            GarageController gc = new GarageController();
            ApiResult<GarageDTO> garageDTO = new ApiResult<GarageDTO>();

            // Default Car
            garageDTO = gc.Get(carID);

            Assert.IsNotNull(garageDTO);
            Assert.IsNotNull(garageDTO.Data.Name);
            Assert.IsNotNull(garageDTO.Data.Address);
            Assert.IsNotNull(garageDTO.Data.MaxCar);
            Assert.AreEqual((int)HttpStatusCode.OK, garageDTO.StatusCode);
        }

        [TestMethod]
        public void GarageController_Post()
        {
            GarageController gc = new GarageController();
            ApiResult<GarageDTO> resultGarage = gc.Post(new GarageDTO()
            {
                Name = "TEST_GARAGE_POST" + DateTime.Now.ToString(),
                Address = "TEST_ADDRESS",
                Status = (int)Enumaration.Status.Deleted,
                MaxCar = 100
            });
            Assert.IsNotNull(resultGarage);
            Assert.IsNotNull(resultGarage.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, resultGarage.StatusCode);
        }

        [TestMethod]
        public void GarageController_Put()
        {
            GarageController gc = new GarageController();
            ApiResult<GarageDTO> resultGarage = gc.Put(new GarageDTO()
            {
                ID = garageID, // Default Garage ID
                Name = "TEST_GARAGE_PUT" + DateTime.Now.ToString(),
                Address = "TEST_UPDATED_ADDRESS",
                Status = (int)Enumaration.Status.Active,
                MaxCar = 100
            });
            Assert.IsNotNull(resultGarage);
            Assert.IsNotNull(resultGarage.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, resultGarage.StatusCode);
        }

        [TestMethod]
        public void GarageController_Delete()
        {
            GarageController gc = new GarageController();
            ApiResult resultGarageDeleted = gc.Delete(garageID);

            Assert.IsNotNull(resultGarageDeleted);
            Assert.AreEqual((int)HttpStatusCode.OK, resultGarageDeleted.StatusCode);
        }
    }
}
