using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.Tank;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class LiquidTankTest
    {
        [Test]
        public void Should_ThrowArgumentNullException_WhenParameterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new LiquidTank(null));
        }

        [Test]
        public void Should_CreateNewObject_WithValidParameter_TankIsNotNull()
        {
            var container = new LiquidTank(new Component("abc", ComponentType.LIQUID, false));
            Assert.IsNotNull(container);
        }

        [Test]
        public void Should_CreateNewObject_WithValidParameter_ComponentIsNotNull()
        {
            var container = new LiquidTank(new Component("abc", ComponentType.LIQUID, false));
            Assert.IsNotNull(container.Component);
        }

        [Test]
        public void Should_CreateNewObject_WithValidParameter_ComponentTypeIsValidFromInserted()
        {
            var container = new LiquidTank(new Component("abc", ComponentType.LIQUID, false));
            Assert.AreEqual(ComponentType.LIQUID, container.Component.Type);
        }

        [Test]
        public void Should_CreateNewObject_WithValidParameter_NameIsValidFromInserted()
        {
            var container = new LiquidTank(new Component("abc", ComponentType.LIQUID, false));
            Assert.AreEqual("abc", container.Component.Name);
        }

        [Test]
        public void Should_ThrowArgumentException_WithIncorrectType()
        {
            Assert.Throws<ArgumentException>(() => new LiquidTank(new Component("abc", ComponentType.DRY, false)));
        }
    }
}
