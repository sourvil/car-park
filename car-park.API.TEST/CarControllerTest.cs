using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_park.Common;
using car_park.API.Controllers;
using System.Collections.Generic;
using car_park.DTO;
using System.Net;

namespace car_park.API.TEST
{
    [TestClass]
    public class CarControllerTest
    {
        // Default ID values
        private int garageID = 1, carID = 1;
        public CarControllerTest()
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
        public void CarController_Get_All()
        {
            CarController cc = new CarController();
            ApiResult<List<CarDTO>> lstCar = new ApiResult<List<CarDTO>>();

            lstCar = cc.Get();

            Assert.IsNotNull(lstCar);
            Assert.AreEqual((int)HttpStatusCode.OK, lstCar.StatusCode);
        }

        [TestMethod]
        public void CarController_Get_ById()
        {
            CarController cc = new CarController();
            ApiResult<CarDTO> carDTO = new ApiResult<CarDTO>();

            // Default Car
            carDTO = cc.Get(carID);

            Assert.IsNotNull(carDTO);
            Assert.IsNotNull(carDTO.Data.Name);
            Assert.IsNotNull(carDTO.Data.Year);
            Assert.IsNotNull(carDTO.Data.GarageID);
            Assert.IsNotNull(carDTO.Data.RegistrationDate);
            Assert.AreEqual((int)HttpStatusCode.OK, carDTO.StatusCode);
        }

        [TestMethod]
        public void CarController_Post()
        {
            CarController cc = new CarController();
            CarDTO carDTO = new CarDTO();
            carDTO.Name = "CAR_TEST_NAME";
            carDTO.Year = DateTime.Today.Year;
            carDTO.RegistrationDate = DateTime.Today;
            carDTO.GarageID = garageID; // Default Garage
            ApiResult<CarDTO> result =  cc.Post(carDTO);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void CarController_Put()
        {
            CarController cc = new CarController();
            CarDTO carDTO = new CarDTO();
            carDTO.ID = carID;  // Default CarID
            carDTO.Name = "CAR_TEST_NAME";
            carDTO.Year = DateTime.Today.Year;
            carDTO.RegistrationDate = DateTime.Today;
            carDTO.GarageID = garageID;
            ApiResult<CarDTO> result = cc.Put(carDTO);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }        
    }
}
