using System;
using CoffeeMake.Includes.Types;
using CoffeeMake.Interfaces;
using System.Linq;
using NUnit.Framework;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class DrinkWithComponentTest
    {
        [Test]
        public void Should_ThrowArgumentNullException_WithNullComponents()
        {
            IDrink currentDrink = new Drink();

            Assert.Throws<ArgumentNullException>(() => currentDrink = new WithComponent(currentDrink, null));

            Assert.IsFalse(currentDrink.Components.Any());
        }

        [Test]
        public void Should_CreateNewObject_WithCorrectComponents()
        {
            IDrink currentDrink = new Drink();

            Assert.DoesNotThrow(() => currentDrink = new WithComponent(currentDrink, new Component("parowka", ComponentType.OTHER, false)));

            Assert.IsTrue(currentDrink.Components.Any());
        }
    }
}
