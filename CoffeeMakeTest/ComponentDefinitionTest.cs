using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Includes.Types;

namespace CoffeeMakeTest
{
    [TestClass]
    public class ComponentDefinitionTest
    {
        public const string TEST_NAME = "testowy";

        [TestMethod, TestCategory("ComponentDefinitionTest")]
        public void ComponentDefinitionAmount()
        {
            var compDef = new ComponentDefinition(TEST_NAME, 50);
            Assert.AreEqual(50, compDef.GetAmount());
        }

        [TestMethod, TestCategory("ComponentDefinitionTest")]
        public void ComponentDefinitionAmountAndTemp()
        {
            var compDef = new ComponentDefinition(TEST_NAME, 50, 100);
            Assert.AreEqual(100, compDef.GetAmount());

            Assert.AreEqual(50, compDef.GetTemperature());
        }
    }
}
