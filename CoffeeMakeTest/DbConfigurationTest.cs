using System;
using NUnit.Framework;
using CoffeeMake.Configuration;
using System.Linq;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class DbConfigurationTest
    {
        [Test]
        public void Should_Return_Same_Instance()
        {
            var conf = DbSingletonConfiguration.Instance;
            var conf2 = DbSingletonConfiguration.Instance;
            Assert.AreEqual(conf, conf2);
        }

        [Test]
        public void Should_Return_Empty_Components()
        {
            var conf = DbSingletonConfiguration.Instance;
            Assert.IsNotNull(conf.Components);
            Assert.IsFalse(conf.Components.Any());
        }

        [Test]
        public void Should_Return_Empty_Recipes()
        {
            var conf = DbSingletonConfiguration.Instance;
            Assert.IsNotNull(conf.Recipes);
            Assert.IsFalse(conf.Recipes.Any());
        }
    }
}
