using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_park.Common;
using System.Collections.Generic;
using car_park.DTO;
using System.Net;

namespace car_park.BUS.TEST
{
    [TestClass]
    public class CarServiceTest
    {
        // Default ID values
        private int garageID = 1, carID = 1;

        // Prepare default records
        public CarServiceTest()
        {
            // Activate Default Car if deleted
            CarService cs = new CarService();
            CarDTO carDTO = new CarDTO();
            carDTO.ID = carID;  // Default CarID
            carDTO.Name = "CAR_TEST_NAME";
            carDTO.Year = DateTime.Today.Year;
            carDTO.RegistrationDate = DateTime.Today;
            carDTO.GarageID = garageID;
            carDTO.Status = (int)Enumaration.Status.Active;
            ApiResult<CarDTO> result = cs.Put(carDTO);


            // Activate Default Garage if deleted
            GarageService gs = new GarageService();
            ApiResult<GarageDTO> resultGarage = gs.Put(new GarageDTO()
            {
                ID = garageID, // Default Garage ID
                Name = "TEST_GARAGE_PUT" + DateTime.Now.ToString(),
                Address = "TEST_UPDATED_ADDRESS",
                Status = (int)Enumaration.Status.Active,
                MaxCar = 100
            });
        }

        [TestMethod]
        public void Car_Get_All()
        {
            CarService cs = new CarService();
            ApiResult<List<CarDTO>> lstCar = new ApiResult<List<CarDTO>>();

            lstCar = cs.Get();

            Assert.IsNotNull(lstCar);
            Assert.AreEqual((int)HttpStatusCode.OK, lstCar.StatusCode);
        }

        [TestMethod]
        public void Car_Get_ById()
        {
            CarService cs = new CarService();
            ApiResult<CarDTO> carDTO = new ApiResult<CarDTO>();

            // Default Car
            carDTO = cs.Get(carID);

            Assert.IsNotNull(carDTO);
            Assert.IsNotNull(carDTO.Data.Name);
            Assert.IsNotNull(carDTO.Data.Year);
            Assert.IsNotNull(carDTO.Data.GarageID);
            Assert.IsNotNull(carDTO.Data.RegistrationDate);
            Assert.AreEqual((int)HttpStatusCode.OK, carDTO.StatusCode);
        }

        [TestMethod]
        public void Car_Post()
        {
            CarService cs = new CarService();
            CarDTO carDTO = new CarDTO();
            carDTO.Name = "CAR_TEST_NAME";
            carDTO.Year = DateTime.Today.Year;
            carDTO.RegistrationDate = DateTime.Today;
            carDTO.GarageID = garageID; // Default Garage
            carDTO.Status = (int)Enumaration.Status.Deleted;
            ApiResult<CarDTO> result =  cs.Post(carDTO);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void Car_Put()
        {
            CarService cs = new CarService();
            CarDTO carDTO = new CarDTO();
            carDTO.ID = carID;  // Default CarID
            carDTO.Name = "CAR_TEST_NAME";
            carDTO.Year = DateTime.Today.Year;
            carDTO.RegistrationDate = DateTime.Today;
            carDTO.GarageID = garageID;
            ApiResult<CarDTO> result = cs.Put(carDTO);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void Car_CheckGarageAvailability_FullNot()
        {
            // Create a Garage with 0 Capacity
            BUS.GarageService gs = new BUS.GarageService();
            ApiResult<GarageDTO> resultGarage =  gs.Post(new GarageDTO() {
                Name = "TEST_GARAGE_ZERO_CAPACITY" + DateTime.Now.ToString(),
                Address = "TEST_ADDRESS",
                Status = (int)Enumaration.Status.Active,
                MaxCar = 0 
            });
            Assert.IsNotNull(resultGarage);
            Assert.IsNotNull(resultGarage.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, resultGarage.StatusCode);
            var garageID = resultGarage.Data.ID;

            // Get a Car
            CarService cs = new CarService();
            ApiResult<CarDTO> resultCar = cs.Get(carID);
            Assert.IsNotNull(resultCar);
            Assert.IsNotNull(resultCar.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, resultCar.StatusCode);

            // Try to Move this car to 0 capacity Garage
            // Should return False
            CarDTO carDTO = resultCar.Data;
            carDTO.GarageID = garageID;
            Assert.IsFalse(cs.CheckGarageAvailability(carDTO));
            
            // Delete Garage
            ApiResult resultGarageDeleted = gs.Delete(garageID);
            Assert.IsNotNull(resultGarageDeleted);
            Assert.AreEqual((int)HttpStatusCode.OK, resultGarageDeleted.StatusCode);
        }

        [TestMethod]
        public void Car_CheckGarageAvailability_EmptyOk()
        {
            // Create a Garage with 0 Capacity
            BUS.GarageService gs = new BUS.GarageService();
            ApiResult<GarageDTO> resultGarage = gs.Post(new GarageDTO()
            {
                Name = "TEST_GARAGE_ONE_CAPACITY" + DateTime.Now.ToString(),
                Address = "TEST_ADDRESS",
                Status = (int)Enumaration.Status.Active,
                MaxCar = 1
            });
            Assert.IsNotNull(resultGarage);
            Assert.IsNotNull(resultGarage.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, resultGarage.StatusCode);
            var garageID = resultGarage.Data.ID;

            // Get a Car
            CarService cs = new CarService();
            ApiResult<CarDTO> resultCar = cs.Get(carID);
            Assert.IsNotNull(resultCar);
            Assert.IsNotNull(resultCar.Data);
            Assert.AreEqual((int)HttpStatusCode.OK, resultCar.StatusCode);

            // Try to Move this car to 0 capacity Garage
            // Should return False
            CarDTO carDTO = resultCar.Data;
            carDTO.GarageID = garageID;
            Assert.IsTrue(cs.CheckGarageAvailability(carDTO));

            // Delete Garage
            ApiResult resultGarageDeleted = gs.Delete(garageID);
            Assert.IsNotNull(resultGarageDeleted);
            Assert.AreEqual((int)HttpStatusCode.OK, resultGarageDeleted.StatusCode);
        }
    }
}
