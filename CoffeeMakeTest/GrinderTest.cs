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
    public class GrinderTest
    {
        [Test]
        public void Should_CreateObject_AndNotNull()
        {
            Assert.DoesNotThrow(() => 
                {
                    var gridner = new Grinder();
                    Assert.IsNotNull(gridner);
                });
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenCallMethodWithNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => new Grinder().Grind(null));
        }

        [Test]
        public void Should_ThrowArgumentException_WhenCallMethodWithNotGrindableComponent()
        {
            Assert.Throws<ArgumentException>(() => new Grinder().Grind(new Component("asd", ComponentType.DRY, false)));
        }

        [Test]
        public void Should_ThrowArgumentException_WhenCallMethodWithLiquidComponent()
        {
            Assert.Throws<ArgumentException>(() => new Grinder().Grind(new Component("asd", ComponentType.LIQUID, true)));
        }

        [Test]
        public void Should_GrindComponent_WhenCallMethodWithCorrectParameters()
        {
            Assert.DoesNotThrow(() => new Grinder().Grind(new Component("asd", ComponentType.DRY, true)));
        }
    }
}
