using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.Tank;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class HeaterTest
    {
        [Test]
        public void Should_CreateObject_AndNotNull()
        {
            Assert.DoesNotThrow(() => new Heater());
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenCallMethodWithNullParameter()
        {
            Assert.DoesNotThrow(() => new Heater());

            Assert.Throws<ArgumentNullException>(() => new Heater().Heat(null, 2));
        }

        [Test]
        public void Should_ThrowArgumentException_WhenCallMethodWithMinusTemperature()
        {
            Assert.Throws<ArgumentException>(() => new Heater().Heat(new Component("asd", ComponentType.LIQUID, false), -5));
        }

        [Test]
        public void Should_ThrowArgumentException_WhenCallMethodWithDryComponent()
        {
            Assert.Throws<ArgumentException>(() => new Heater().Heat(new Component("asd", ComponentType.DRY, true), 45));
        }

        [Test]
        public void Should_HeatComponent_WhenCallMethodWithCorrectParameters()
        {
            Assert.DoesNotThrow(() => new Heater().Heat(new Component("asd", ComponentType.LIQUID, true), 2));
        }

        [Test]
        public void Should_HeatComponent_WithVerifyInsertedTemperature()
        {
            var componentn =new Component("asd", ComponentType.LIQUID, true);
            new Heater().Heat(componentn, 27);
            Assert.AreEqual(27, componentn.Temperature);
        }

    }
}
