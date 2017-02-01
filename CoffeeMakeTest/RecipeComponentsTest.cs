using CoffeeMake.Includes.Types;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class RecipeComponentsTest
    {
        [Test]
        public void Should_CreateObject_WhenNotSetCtorParameter()
        {
            Assert.DoesNotThrow(() => new RecipeComponents());
        }

        [Test]
        public void Should_CreateObject_WhenSetCtorParameter()
        {
            Assert.DoesNotThrow(() => new RecipeComponents(new List<ComponentDefinition>()));
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenSetCtorNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => new RecipeComponents(null));
        }
    }
}
