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
            var conf = SingletonConfiguration.Instance;
            var conf2 = SingletonConfiguration.Instance;
            Assert.AreEqual(conf, conf2);
        }

        [Test]
        public void Should_Return_Empty_Components()
        {
            var conf = SingletonConfiguration.Instance;
            Assert.IsNotNull(conf.Components);
            Assert.IsFalse(conf.Components.Any());
        }

        [Test]
        public void Should_Return_Empty_Recipes()
        {
            var conf = SingletonConfiguration.Instance;
            Assert.IsNotNull(conf.Recipes);
            Assert.IsFalse(conf.Recipes.Any());
        }
    }
}
