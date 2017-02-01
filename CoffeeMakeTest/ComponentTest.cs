using CoffeeMake.Includes.Types;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class ComponentTest
    {
        [TestCaseSource(typeof(ComponentDataClass), "NullArguments")]
        public void Should_ThrowArgumentNullException_WhenParameterIsNull(string name, ComponentType type, bool grind)
        {
            Assert.Throws<ArgumentNullException>(() => new Component(name, type, grind));
        }

        [Test]
        public void Should_ThrowArgumentException_WhenSetMinusTemperature()
        {
            var component = new Component("test", ComponentType.DRY, false);
            Assert.Throws<ArgumentException>(() => component.Temperature = -1);
        }

        [Test]
        public void Should_CreateObject_WithoutException()
        {
            Assert.DoesNotThrow(() => new Component("test", ComponentType.DRY, false));
        } 
    }

    public class ComponentDataClass
    {
        public static IEnumerable NullArguments
        {
            get
            {
                yield return new TestCaseData(null, ComponentType.DRY, false);
            }
        }
    }
}
