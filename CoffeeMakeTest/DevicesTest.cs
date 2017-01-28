using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Includes.Types.FDevices;
using CoffeeMake.Interfaces;

namespace CoffeeMakeTest
{
    [TestClass]
    public class DevicesTest
    {
        [TestMethod, TestCategory("DevicesTest")]
        public void DevicesGetTest()
        {
            Devices devices = new Devices();

            IDevice newDevice = new Head("Glowica");
            devices.Add(newDevice);
            try
            {
                var testDevice = devices.Get("testowe urzadzenie");
                Assert.Fail();
            }
            catch (NullReferenceException e)
            {
                Assert.IsTrue(true);
            }

            try
            {
                var testDevice = devices.Get("Glowica");
                Assert.AreEqual(testDevice, newDevice);
            }
            catch (ArgumentException e)
            {
                Assert.Fail();
            }
        }

        [TestMethod, TestCategory("DevicesTest")]
        public void DevicesHeaterDeviceTest()
        {
            Devices devices = new Devices();
            try
            {
                var testDevice = devices.GetHeater();
                Assert.Fail();
            }
            catch (NullReferenceException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod, TestCategory("DevicesTest")]
        public void DevicesAddTest()
        {
            Devices devices = new Devices();
            try
            {
                devices.Add(null);
                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod, TestCategory("DevicesTest")]
        public void DevicesHeadDeviceTest()
        {
            Devices devices = new Devices();
            IDevice newDevice = new Head("Glowica");
            devices.Add(newDevice);
            try
            {
                var testDevice = devices.GetHead();
                Assert.AreEqual(testDevice, newDevice);
            }
            catch (ArgumentException e)
            {
                Assert.Fail();
            }
        }
    }
}
