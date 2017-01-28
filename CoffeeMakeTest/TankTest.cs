using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Interfaces;
using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.ComponentType;
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
            IComponentType exampleType = new Dry();
            IComponent exampleComponentn = new Component(TEST_NAME, exampleType, false);

            ITank tank = new Tank(TEST_NAME, TEST_CAPACITY, exampleType, exampleComponentn);

            tank.RemoveContent(50);
            Assert.AreEqual(50, tank.GetCapacity());
            tank.RemoveContent(1);
            Assert.AreNotEqual(20, tank.GetCapacity());
        }

        [TestMethod, TestCategory("TankTest")]
        public void TankNameNotEqualWithComponent()
        {
            IComponentType exampleType = new Dry();
            IComponent exampleComponentn = new Component("testowy produkt", exampleType, false);
            try
            {
                ITank tank = new Tank(TEST_NAME, TEST_CAPACITY, exampleType, exampleComponentn);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod, TestCategory("TankTest")]
        public void TankNameTest()
        {
            ITank tank = new Tank();
            Assert.AreEqual(tank.GetName(), "Brak");
            tank.SetName(TEST_NAME);
            Assert.AreEqual(tank.GetName(), TEST_NAME);
        }
    }
}
