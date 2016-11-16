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
            CarDTO result = cs.Put(carDTO);


            // Activate Default Garage if deleted
            GarageService gs = new GarageService();
            GarageDTO resultGarage = gs.Put(new GarageDTO()
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
            List<CarDTO> lstCar = new List<CarDTO>();

            lstCar = cs.Get();

            Assert.IsNotNull(lstCar);
        }

        [TestMethod]
        public void Car_Get_ById()
        {
            CarService cs = new CarService();
            CarDTO carDTO = new CarDTO();

            // Default Car
            carDTO = cs.Get(carID);

            Assert.IsNotNull(carDTO);
            Assert.IsNotNull(carDTO.Name);
            Assert.IsNotNull(carDTO.Year);
            Assert.IsNotNull(carDTO.GarageID);
            Assert.IsNotNull(carDTO.RegistrationDate);
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
            CarDTO result =  cs.Post(carDTO);

            Assert.IsNotNull(result);
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
            CarDTO result = cs.Put(carDTO);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Car_CheckGarageAvailability_FullNot()
        {
            // Create a Garage with 0 Capacity
            BUS.GarageService gs = new BUS.GarageService();
            GarageDTO resultGarage =  gs.Post(new GarageDTO() {
                Name = "TEST_GARAGE_ZERO_CAPACITY" + DateTime.Now.ToString(),
                Address = "TEST_ADDRESS",
                Status = (int)Enumaration.Status.Active,
                MaxCar = 0 
            });
            Assert.IsNotNull(resultGarage);
            var garageID = resultGarage.ID;

            // Get a Car
            CarService cs = new CarService();
            CarDTO resultCar = cs.Get(carID);
            Assert.IsNotNull(resultCar);

            // Try to Move this car to 0 capacity Garage
            // Should return False
            CarDTO carDTO = resultCar;
            carDTO.GarageID = garageID;
            Assert.IsFalse(cs.CheckGarageAvailability(carDTO));

            // Delete Garage
            gs.Delete(garageID);
        }

        [TestMethod]
        public void Car_CheckGarageAvailability_EmptyOk()
        {
            // Create a Garage with 0 Capacity
            BUS.GarageService gs = new BUS.GarageService();
            GarageDTO resultGarage = gs.Post(new GarageDTO()
            {
                Name = "TEST_GARAGE_ONE_CAPACITY" + DateTime.Now.ToString(),
                Address = "TEST_ADDRESS",
                Status = (int)Enumaration.Status.Active,
                MaxCar = 1
            });
            Assert.IsNotNull(resultGarage);
            var garageID = resultGarage.ID;

            // Get a Car
            CarService cs = new CarService();
            CarDTO resultCar = cs.Get(carID);
            Assert.IsNotNull(resultCar);

            // Try to Move this car to 0 capacity Garage
            // Should return False
            CarDTO carDTO = resultCar;
            carDTO.GarageID = garageID;
            Assert.IsTrue(cs.CheckGarageAvailability(carDTO));

            // Delete Garage
            gs.Delete(garageID);
        }
    }
}
