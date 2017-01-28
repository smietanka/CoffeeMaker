using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Includes.Types.FDevices;
using CoffeeMake.Interfaces;
using CoffeeMake.Includes.Types;
using System.Linq;

namespace CoffeeMakeTest
{
    [TestClass]
    public class RecipeTest
    {
        public const string TEST_NAME = "testowy";

        [TestMethod, TestCategory("RecipeTest")]
        public void RecipeCreate()
        {
            Recipe recipe = new Recipe();

            Assert.IsTrue(!recipe.GetComponents().Any());

        }

        [TestMethod, TestCategory("RecipeTest")]
        public void RecipeAddComponentDefinition()
        {
            Recipe recipe = new Recipe();

            try
            {
                recipe.AddComponentDefinition(null);
                Assert.Fail();
            }
            catch(ArgumentNullException e)
            {
                Assert.IsTrue(true);
            }

            var compDef = new ComponentDefinition(TEST_NAME, 50);
            Assert.AreEqual(50, compDef.GetAmount());

            recipe.AddComponentDefinition(compDef);

            Assert.IsTrue(recipe.GetComponents().Any());
        }
    }
}
