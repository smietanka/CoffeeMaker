using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.Tank;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class DevicesTest
    {
        [Test]
        public void Should_CreateObject_AndNotNull()
        {
            Assert.DoesNotThrow(() => 
                {
                    var devices = new Devices();
                    Assert.IsNotNull(devices);
                });
        }

        [Test]
        public void Should_CreateObject_AndGrinderIsNotNull()
        {
            Assert.DoesNotThrow(() =>
            {
                var devices = new Devices();
                Assert.IsNotNull(devices.Grinder);
            });
        }

        [Test]
        public void Should_CreateObject_AndHeaterIsNotNull()
        {
            Assert.DoesNotThrow(() =>
            {
                var devices = new Devices();
                Assert.IsNotNull(devices.Heater);
            });
        }
        [Test]
        public void Should_CreateObject_AndHeadIsNotNull()
        {
            Assert.DoesNotThrow(() =>
            {
                var devices = new Devices();
                Assert.IsNotNull(devices.Head);
            });
        }
        [Test]
        public void Should_CreateObject_AndPumpIsNotNull()
        {
            Assert.DoesNotThrow(() =>
            {
                var devices = new Devices();
                Assert.IsNotNull(devices.Pump);
            });
        }
    }
}
