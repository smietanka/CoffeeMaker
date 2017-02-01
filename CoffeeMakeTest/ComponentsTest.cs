using CoffeeMake.Includes.Types;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class ComponentsTest
    {
        [Test]
        public void Should_CreateObject_WhenNotSetCtorParameter()
        {
            Assert.DoesNotThrow(() => new Components());
        }

        [Test]
        public void Should_CreateObject_WhenSetCtorParameter()
        {
            Assert.DoesNotThrow(() => new Components(new List<Component>()));
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenSetCtorNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => new Components(null));
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenAddNullParameter()
        {
            var comps = new Components();
            Assert.Throws<ArgumentNullException>(() => comps.Add(null));
        }

        [Test]
        public void Should_AddComponent_WhenAddCorrectParameter()
        {
            var comps = new Components();
            Assert.DoesNotThrow(() => comps.Add(new Component("asd", ComponentType.DRY, false)));
        } 
    }
}
