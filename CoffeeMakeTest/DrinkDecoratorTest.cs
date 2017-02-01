using System;
using CoffeeMake.Includes.Types;
using CoffeeMake.Interfaces;
using System.Linq;
using NUnit.Framework;

namespace CoffeeMakeTest
{
    public class DrinkDecoratorAbstractTesting : DrinkDecorator
    {
        public DrinkDecoratorAbstractTesting(IDrink drink)
            : base(drink)
        {

        }
    }

    [TestFixture]
    public class DrinkDecoratorTest
    {
        [Test]
        public void Should_CreateNewObject_WithEmptyComponents()
        {
            var decorator = new DrinkDecoratorAbstractTesting(new Drink());
            Assert.IsFalse(decorator.Components.Any());
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenParameterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DrinkDecoratorAbstractTesting(null));
        }
    }
}
