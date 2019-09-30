using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoRepair;

namespace CarTest
{
    [TestClass]
    public class ParsLaborTest
    {
        [TestMethod]
        public void TestAddTime()
        {
            PartsLaborRepair repair = new PartsLaborRepair("123", DateTime.Now);
            repair.AddMinutes(30);
            Assert.AreEqual(30, repair.Minutes);
            repair.AddHours(0.75);
            Assert.AreEqual(75, repair.Minutes);
            repair.AddHours(-1.3);
            Assert.AreEqual(75, repair.Minutes);
            repair.AddMinutes(-10);
            Assert.AreEqual(75, repair.Minutes);
        }

        [TestMethod]
        public void TestAmount()
        {
            PartsLaborRepair repair = new PartsLaborRepair("123", DateTime.Now);
            Part fender = new Part("Fender", 200.00f);
            Part tire = new Part("Tire", 100.10f);
            repair.AddPart(fender);
            repair.AddPart(tire);
            repair.AddMinutes(30);
            repair.AddHours(0.5);
            Assert.AreEqual(200 + 100.1 + 75, repair.Amount, 0.001);
        }
    }
}
