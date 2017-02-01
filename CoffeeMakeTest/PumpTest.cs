using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.Tank;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class PumpTest
    {
        [Test]
        public void Should_ThrowArgumentNullException_WhenArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Pump(null));
        }

        [Test]
        public void Should_CreateObject_WhenArgumentIsCorrect()
        {
            Assert.DoesNotThrow(() => new Pump(new Head()));
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenPumpingNullComponent()
        {
            var pump = new Pump(new Head());
            Assert.Throws<ArgumentNullException>(() => pump.Pumping(null));
        }

        [Test]
        public void Should_PumpingComponent_WhenArgumentIsCorrect()
        {
            var pump = new Pump(new Head());
            Assert.DoesNotThrow(() => pump.Pumping(new Component("asd", ComponentType.DRY, false)));
        }

        [Test]
        public void Should_PumpingNullComponent_CheckHeadIsEmpty()
        {
            var head = new Head();
            var pump = new Pump(head);
            Assert.Throws<ArgumentNullException>(() => pump.Pumping(null));
            Assert.IsFalse(head.Any());
        }

        [Test]
        public void Should_PumpingComponent_CheckHeadIsNotEmpty()
        {
            var head = new Head();
            var pump = new Pump(head);
            pump.Pumping(new Component("asd", ComponentType.DRY, false));
            Assert.IsTrue(head.Any());
        }

        [Test]
        public void Should_PumpingComponent_CheckInHeadInsertedComponentIsIn()
        {
            var head = new Head();
            var pump = new Pump(head);
            var compo = new Component("asd", ComponentType.DRY, false);
            pump.Pumping(compo);

            Assert.IsTrue(head.Contains(compo));
            Assert.IsFalse(head.Contains(new Component("asdd", ComponentType.DRY, false)));
        }

    }
}
