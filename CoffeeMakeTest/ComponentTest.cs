using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Interfaces;
using CoffeeMake.Includes.Types.ComponentType;
using CoffeeMake.Includes.Types;

namespace CoffeeMakeTest
{
    [TestClass]
    public class ComponentTest
    {
        public const string TEST_NAME = "testowy";

        [TestMethod, TestCategory("ComponentTest")]
        public void ComponentNameTest()
        {
            IComponent component = new Component();

            Assert.AreEqual("brak", component.GetName());
            component.SetName(TEST_NAME);
            Assert.AreEqual(TEST_NAME, component.GetName());
        }

        [TestMethod, TestCategory("ComponentTest")]
        public void ComponentTypeTest()
        {
            IComponent component = new Component();

            IComponentType compoType = new Dry();
            Assert.AreEqual(Constans.DRY_TYPE, compoType.GetName());

            Assert.AreNotEqual("zla nazwa", compoType.GetName());

            IComponentType compoLiquidType = new Liquid();
            Assert.AreEqual(Constans.LIQUID_TYPE, compoLiquidType.GetName());

            Assert.AreNotEqual("zla nazwa", compoLiquidType.GetName());

            Assert.AreEqual(new Dry().GetName(), component.GetComponentType().GetName());
        }

        [TestMethod, TestCategory("ComponentTest")]
        public void ComponentGrindableTest()
        {
            IComponent component = new Component();

            Assert.IsFalse(component.GetGrindable());
            component.SetGrindable(true);
            Assert.IsTrue(component.GetGrindable());
        }

        [TestMethod, TestCategory("ComponentTest")]
        public void ComponentTemperatureTest()
        {
            IComponent component = new Component();

            Assert.AreEqual(0, component.GetTemperature());
            component.SetTemperature(40);
            Assert.AreEqual(40, component.GetTemperature());
        }
    }
}
