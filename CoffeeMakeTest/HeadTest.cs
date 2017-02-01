using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.Tank;
using CoffeeMake.Interfaces;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMakeTest
{
    [TestFixture]
    public class HeadTest
    {
        [Test]
        public void Should_CreateObject_AndNotNull()
        {
            Assert.DoesNotThrow(() => new Head());
        }

        [Test]
        public void Should_CreateObject_AndComponentsIsEmpty()
        {
            var head = new Head();
            Assert.IsFalse(head.Any());
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenAddNullParameter()
        {
            var head = new Head();
            Assert.Throws<ArgumentNullException>(() => head.Add(null));
        }

        [Test]
        public void Should_ThrowArgumentNullException_WhenAddNullParameter_AndCollectionIsEmpty()
        {
            var head = new Head();
            Assert.Throws<ArgumentNullException>(() => head.Add(null));
            Assert.IsFalse(head.Any());
        }

        [Test]
        public void Should_AddCorrectComponent()
        {
            var head = new Head();
            Assert.DoesNotThrow(() => head.Add(new Component("asd", ComponentType.DRY, false)));
        }

        [Test]
        public void Should_AddCorrectComponent_HeadIsNotEmpty()
        {
            var head = new Head();
            Assert.DoesNotThrow(() => head.Add(new Component("asd", ComponentType.DRY, false)));

            Assert.IsTrue(head.Any());
        }

    }
}
