using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Interfaces;
using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.FDevices;

namespace CoffeeMakeTest
{
    [TestClass]
    public class TankTest
    {
        public const string TEST_NAME = "testowy";
        public const float TEST_CAPACITY = 100;

        [TestMethod, TestCategory("TankTest")]
        public void TankCapacityChange()
        {
            Component exampleComponentn = new Component(TEST_NAME, ComponentType.DRY, false);

            //ITank tank = new Tank(TEST_NAME, TEST_CAPACITY, ComponentType.DRY, exampleComponentn);

            //tank.RemoveContent(50);
            //Assert.AreEqual(50, tank.Capacity);
            //tank.RemoveContent(1);
            //Assert.AreNotEqual(20, tank.Capacity);
        }

        [TestMethod, TestCategory("TankTest")]
        public void TankNameNotEqualWithComponent()
        {
            Component exampleComponentn = new Component("testowy produkt", ComponentType.DRY, false);
            try
            {
                //ITank tank = new Tank(TEST_NAME, TEST_CAPACITY, ComponentType.DRY, exampleComponentn);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod, TestCategory("TankTest")]
        public void CreateTankObject()
        {
            //ITank tank = new Tank(null, 123, ComponentType.DRY, null);
            ITank tank = new Tank("dadas", 123, ComponentType.DRY, new Component("dadas", ComponentType.DRY, false));
            Assert.IsTrue(true);
        }
    }
}
