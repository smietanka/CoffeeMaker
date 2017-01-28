using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Interfaces;
using CoffeeMake.Includes.Types.FDevices;
using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.ComponentType;

namespace CoffeeMakeTest
{
    [TestClass]
    public class HeatTest
    {
        public const string TEST_NAME = "testowy";

        [TestMethod, TestCategory("HeatTest")]
        public void HeatComponentTest()
        {
            IComponentType exampleType = new Dry();
            IComponent exampleComponentn = new Component(TEST_NAME, exampleType, false);

            IHeater heat = new Heater(TEST_NAME);
            Assert.IsTrue(heat.Heat(exampleComponentn, 100));
            try
            {
                heat.Heat(exampleComponentn, -1);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod, TestCategory("HeatTest")]
        public void HeatNameTest()
        {
            IHeater heat = new Heater();
            Assert.AreEqual(heat.GetName(), "Brak");

            heat.SetName(TEST_NAME);
            Assert.AreEqual(TEST_NAME, heat.GetName());
        }
    }
}
