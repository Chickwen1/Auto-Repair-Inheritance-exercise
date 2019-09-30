using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoRepair;
using System.Collections.Generic;

namespace CarTest
{
    [TestClass]
    public class CarTest
    {
        Car ford;
        Car toyota;
        Car coolCar;
        DateTime jan1_14;
        DateTime feb4_14;
        DateTime feb20;
        DateTime mar3_14;

        [TestInitialize]
        public void SetUp()
        {
            ford = new Car("Ford", "Escape", 2014);
            toyota = new Car("Toyota", "Prius", 2010);
            coolCar = new Car("Tesla", "Model S", 2014);

            jan1_14 = new DateTime(2014, 1, 1);
            feb4_14 = new DateTime(2014, 2, 4);
            mar3_14 = new DateTime(2014, 3, 3);
            feb20 = new DateTime(2014, 2, 20);

            toyota.AddRepair("1011", jan1_14, "Oil change", 20);
            toyota.AddRepair("1012", feb4_14, "balance wheels", 50);

            ListRepair oilChange = new ListRepair("123", feb20, "Oil Change", 30.00);
            ListRepair tireRotation = new ListRepair("124", jan1_14, "Tire Rotation", 15.0);
            Part fender = new Part("Fender", 125);
            PartsLaborRepair plRepair = new PartsLaborRepair("125", mar3_14);
            plRepair.AddPart(fender);
            plRepair.AddHours(2.0);
            coolCar.AddRepair(oilChange);
            coolCar.AddRepair(tireRotation);
            coolCar.AddRepair(plRepair);

        }
        [TestMethod]
        public void testAddOneRepairToCar()
        {
            Car c = new Car("Ford", "Escort", 1998);
            DateTime today = new DateTime();
            c.AddRepair("1615", today, "Oil change", 39.95f);
            Assert.AreEqual(1, c.NumberRepairs());

        }

        [TestMethod]
        public void testAddMultipleRepairs()
        {
            ford.AddRepair("1234", jan1_14, "Check-up", 29.95);
            ford.AddRepair("2345", mar3_14, "Oil change", 25);
            ford.AddRepair("8765", feb20, "replace engine", 4995);
            Assert.AreEqual(3, ford.NumberRepairs());

        }

        [TestMethod]
        public void testRepairAmount()
        {
            Assert.AreEqual(70, toyota.totalRepairAmount());
        }

        [TestMethod]
        public void testLatestRepair()
        {
            Assert.IsNull(ford.LatestRepair());
            Assert.AreEqual(feb4_14, toyota.LatestRepair().RepairDate);
            toyota.AddRepair("1013", mar3_14, "Install new wipers", 20);
            Assert.AreEqual(mar3_14, toyota.LatestRepair().RepairDate);
        }

        [TestMethod]
        public void testRemoveRepairByID()
        {
            toyota.RemoveRepair("1011"); //Remove by ID
            Assert.AreEqual(1, toyota.NumberRepairs());
            toyota.RemoveRepair("xxx"); //Remove a repair that doesn't exist
            Assert.AreEqual(1, toyota.NumberRepairs()); //same number of repairs

        }

        [TestMethod]
        public void testRemoveRepairByDate()
        {
            toyota.RemoveRepair(feb20); //Remove repairs made on February 20 (none for this car)
            Assert.AreEqual(2, toyota.NumberRepairs());
            toyota.RemoveRepair(jan1_14); //One repair made on January 1
            Assert.AreEqual(1, toyota.NumberRepairs());
            toyota.AddRepair("1015", feb20, "Oil change", 23);
            toyota.AddRepair("1016", feb20, "rotate tires", 15); //add two repairs on the same day to ensure both are removed
            Assert.AreEqual(3, toyota.NumberRepairs());
            toyota.RemoveRepair(feb20); //remove multiple repairs on the same date
            Assert.AreEqual(1, toyota.NumberRepairs());
        }

        [TestMethod]
        public void testAddMultipleDiffRepairs()
        {
            Assert.AreEqual(3, coolCar.NumberRepairs());
            Assert.AreEqual(30 + 15 + 125 + 2 * 75, coolCar.totalRepairAmount());
        }


    }
}
