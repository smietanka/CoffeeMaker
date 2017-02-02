using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.Tank;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class DryTankTest
    {
        [Test]
        public void Should_ThrowArgumentNullException_WhenParameterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DryTank(null));
        }

        [Test]
        public void Should_CreateNewObject_WithValidParameter_TankIsNotNull()
        {
            var container = new DryTank(new Component("abc", ComponentType.DRY, false));
            Assert.IsNotNull(container);
        }

        [Test]
        public void Should_CreateNewObject_WithValidParameter_ComponentIsNotNull()
        {
            var container = new DryTank(new Component("abc", ComponentType.DRY, false));
            Assert.IsNotNull(container.Component);
        }

        [Test]
        public void Should_CreateNewObject_WithValidParameter_ComponentTypeIsValidFromInserted()
        {
            var container = new DryTank(new Component("abc", ComponentType.DRY, false));
            Assert.AreEqual(ComponentType.DRY, container.Component.Type);
        }

        [Test]
        public void Should_CreateNewObject_WithValidParameter_NameIsValidFromInserted()
        {
            var container = new DryTank(new Component("abc", ComponentType.DRY, false));
            Assert.AreEqual("abc", container.Component.Name);
        }
    }
}
