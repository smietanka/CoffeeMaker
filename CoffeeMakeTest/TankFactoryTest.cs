using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.Tank;
using NUnit.Framework;
using System;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class TankFactoryTest
    {
        [Test]
        public void CreateContainer_NullArgument_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TankFactory.CreateTank(null));
        }

        [Test]
        public void CreateContainer_IngridientWithUnknownType_NotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => TankFactory.CreateTank(new Component("abc", CoffeeMake.Interfaces.ComponentType.OTHER, false)));
        }
    }
}
