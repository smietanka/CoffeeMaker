using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Interfaces;
using CoffeeMake.Includes.Types.FDevices;
using CoffeeMake.Includes.Types;

namespace CoffeeMakeTest
{
    [TestClass]
    public class HeatTest
    {
        public const string TEST_NAME = "testowy";

        [TestMethod, TestCategory("HeatTest")]
        public void HeatComponentTest()
        {
            Component exampleComponentn = new Component(TEST_NAME, ComponentType.DRY, false);

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
    }
}
