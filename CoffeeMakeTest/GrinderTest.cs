using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Interfaces;
using CoffeeMake.Includes.Types.FDevices;
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
            try
            {
                IGrinder grind = new Grinder(null);
                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(true);
            }

            IGrinder grind2 = new Grinder(TEST_NAME);
            Assert.AreEqual(grind2.Name, TEST_NAME);
        }

        [TestMethod, TestCategory("GrinderTest")]
        public void ComponentGrindableTest()
        {
            IGrinder grinder = new Grinder(TEST_NAME);

            try
            {
                Component notGrindableComp = new Component(TEST_NAME, ComponentType.DRY, false);
                grinder.Grind(notGrindableComp);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(true);
            }

            try
            {
                Component notGrindableComp2 = new Component(TEST_NAME, ComponentType.LIQUID, true);
                grinder.Grind(notGrindableComp2);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(true);
            }

            Component notGrindableComp3 = new Component(TEST_NAME, ComponentType.LIQUID, false);
            try
            {
                grinder.Grind(notGrindableComp3);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(true);
            }

            Component grindableComp = new Component(TEST_NAME, ComponentType.DRY, true);
            Assert.IsTrue(grinder.Grind(grindableComp));
        }
    }
}
