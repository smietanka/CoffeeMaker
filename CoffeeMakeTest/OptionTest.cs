using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMake.Includes.Types;

namespace CoffeeMakeTest
{
    [TestClass]
    public class OptionTest
    {
        public const string TEST_NAME = "testowy";
        [TestMethod, TestCategory("OptionTest")]
        public void OptionNameTest()
        {
            Option opt = new Option();
            Assert.AreEqual("brak", opt.GetName());

            Assert.AreNotEqual("zla nazwa", opt.GetName());

            opt.SetName(TEST_NAME);

            Assert.AreEqual(TEST_NAME, opt.GetName());
        }
    }
}
