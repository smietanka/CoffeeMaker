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
    public class TanksTest
    {
        [Test]
        public void Should_CreateObject_WhenNotSetCtorParameter()
        {
            Assert.DoesNotThrow(() => new Tanks());
        }

        [Test]
        public void Should_CreateObject_WhenSetCtorParameter()
        {
            Assert.DoesNotThrow(() => new Tanks(new List<ITank>()));
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenSetCtorNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => new Components(null));
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenAddNullParameter()
        {
            var tanks = new Tanks();
            Assert.Throws<ArgumentNullException>(() => tanks.Add(null));
        }

        [Test]
        public void Should_AddComponent_WhenAddCorrectParameter()
        {
            var tanks = new Tanks();
            Assert.DoesNotThrow(() => tanks.Add(new DryTank(new Component("asd", ComponentType.DRY, false))));
        }

        [Test]
        public void Should_ThrowArgumentException_WhenComponentTypeIsIncorrect()
        {
            var tanks = new Tanks();
            Assert.Throws<ArgumentException>(() => tanks.Add(new DryTank(new Component("asd", ComponentType.LIQUID, false))));
        } 
    }
}
