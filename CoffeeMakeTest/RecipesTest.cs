using CoffeeMake.Includes.Types;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class RecipesTest
    {
        [Test]
        public void Should_CreateObject_WhenNotSetCtorParameter()
        {
            Assert.DoesNotThrow(() => new Recipes());
        }

        [Test]
        public void Should_CreateObject_WhenSetCtorParameter()
        {
            Assert.DoesNotThrow(() => new Recipes(new List<Recipe>()));
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenSetCtorNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => new Recipes(null));
        }
    }
}
