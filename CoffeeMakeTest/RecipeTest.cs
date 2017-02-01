using CoffeeMake.Includes.Types;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class RecipeTest
    {
        [TestCaseSource(typeof(RecipeDataClass), "NullArguments")]
        public void Should_ThrowArgumentNullException_WhenParameterIsNull(string name, RecipeComponents recipeComp)
        {
            Assert.Throws<ArgumentNullException>(() => new Recipe(name, recipeComp));
        }

        [Test]
        public void Should_ThrowArgumentException_WhenEachOfParameterCollectionIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Recipe("asd", new RecipeComponents(new List<ComponentDefinition>())));
        }

        [Test]
        public void Should_CreateNewObject_WithCorrectParameters()
        {
            Assert.DoesNotThrow(() => {
                var secondRecipe = new Recipe("asd", new RecipeComponents(new List<ComponentDefinition> { new ComponentDefinition("test", 50, 50) }));
                Assert.IsTrue(secondRecipe.RecipeComponents.Any());                
            });
        }
    }

    public class RecipeDataClass
    {
        public static IEnumerable NullArguments
        {
            get
            {
                yield return new TestCaseData(null, new RecipeComponents(new List<ComponentDefinition> { new ComponentDefinition("test", 50, 50) }));
                yield return new TestCaseData("abc", null);
                yield return new TestCaseData(null, null);
            }
        }
    }
}
