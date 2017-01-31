using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Includes.Types;
using CoffeeMake.Interfaces.Drink;
using CoffeeMake.Interfaces;
using System.Linq;

namespace CoffeeMakeTest
{
    [TestClass]
    public class DrinkTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IDrink currentDrink = new Drink();

            currentDrink = new WithComponent(currentDrink, new Component("parowka", ComponentType.OTHER, false));
            currentDrink = new WithComponent(currentDrink, new Component("kupa", ComponentType.OTHER, false));

            Assert.IsTrue(currentDrink.Components.Any());
        }
    }
}
