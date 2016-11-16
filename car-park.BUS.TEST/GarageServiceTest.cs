using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using car_park.Common;
using car_park.DTO;
using System.Net;

namespace car_park.BUS.TEST
{
    [TestClass]
    public class GarageServiceTest
    {
        // Default ID values
        private int garageID = 1, carID = 1;

        // Prepare default records
        public GarageServiceTest()
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
        public void Garage_Get_All()
        {
            GarageService gs = new GarageService();
            List<GarageDTO> lstGarage = new List<GarageDTO>();

            lstGarage = gs.Get();

            Assert.IsNotNull(lstGarage);
        }

        [TestMethod]
        public void Garage_Get_ById()
        {
            GarageService gs = new GarageService();
            GarageDTO garageDTO = new GarageDTO();

            // Default Car
            garageDTO = gs.Get(carID);

            Assert.IsNotNull(garageDTO);
            Assert.IsNotNull(garageDTO.Name);
            Assert.IsNotNull(garageDTO.Address);
            Assert.IsNotNull(garageDTO.MaxCar);
        }

        [TestMethod]
        public void Garage_Post()
        {
            GarageService gs = new GarageService();
            GarageDTO resultGarage = gs.Post(new GarageDTO()
            {
                Name = "TEST_GARAGE_POST" + DateTime.Now.ToString(),
                Address = "TEST_ADDRESS",
                Status = (int)Enumaration.Status.Deleted,
                MaxCar = 0
            });
            Assert.IsNotNull(resultGarage);
        }

        [TestMethod]
        public void Garage_Put()
        {
            GarageService gs = new GarageService();
            GarageDTO resultGarage = gs.Put(new GarageDTO()
            {
                ID = garageID, // Default Garage ID
                Name = "TEST_GARAGE_PUT" + DateTime.Now.ToString(),
                Address = "TEST_UPDATED_ADDRESS",
                Status = (int)Enumaration.Status.Active,
                MaxCar = 0
            });
            Assert.IsNotNull(resultGarage);
        }

        [TestMethod]
        public void Garage_Delete()
        {
            GarageService gs = new GarageService();
            bool resultGarageDeleted = gs.Delete(garageID);

            Assert.IsTrue(resultGarageDeleted);
        }
    }
}
