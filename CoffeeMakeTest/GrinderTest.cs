using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Interfaces;
using CoffeeMake.Includes.Types.FDevices;
using CoffeeMake.Includes.Types.ComponentType;
using CoffeeMake.Includes.Types;

namespace CoffeeMakeTest
{
    [TestClass]
    public class GrinderTest
    {
        public const string TEST_NAME = "testowy";
        [TestMethod, TestCategory("GrinderTest")]
        public void GrinderNameTest()
        {
            IGrinder grind = new Grinder();

            Assert.AreEqual("Brak", grind.GetName());

            try
            {
                grind.SetName(null);
                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(true);
            }

            grind.SetName(TEST_NAME);

            Assert.AreEqual(grind.GetName(), TEST_NAME);
        }

        [TestMethod, TestCategory("GrinderTest")]
        public void ComponentGrindableTest()
        {
            IGrinder grinder = new Grinder(TEST_NAME);

            IComponentType exampleType = new Dry();
            try
            {
                IComponent notGrindableComp = new Component(TEST_NAME, exampleType, false);
                grinder.Grind(notGrindableComp);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(true);
            }

            IComponentType exampleLiquidType = new Liquid();
            try
            {
                IComponent notGrindableComp2 = new Component(TEST_NAME, exampleLiquidType, true);
                grinder.Grind(notGrindableComp2);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(true);
            }

            IComponent notGrindableComp3 = new Component(TEST_NAME, exampleLiquidType, false);
            try
            {
                grinder.Grind(notGrindableComp3);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(true);
            }

            IComponent grindableComp = new Component(TEST_NAME, new Dry(), true);
            Assert.IsTrue(grinder.Grind(grindableComp));
        }
    }
}
