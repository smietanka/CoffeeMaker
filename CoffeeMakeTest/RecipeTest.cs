using CoffeeMake.Includes.Types;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class RecipeTest
    {
        [TestCaseSource(typeof(DataClass), "NullArguments")]
        public void Ctor_NullArguments_ArgumentNullException(string name, RecipeComponents ingridients)
        {
            Assert.Throws<ArgumentNullException>(() => new Recipe(name, ingridients));
        }
    }

    public class DataClass
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
