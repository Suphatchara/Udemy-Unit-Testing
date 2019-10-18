﻿using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinjaUnitTest
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        // SetUp
        // TearDown

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var math = new Math();

            var result = math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));


        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var math = new Math();

            var result = math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));

        }
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheSecondArgument()
        {
            var math = new Math();

            var result = math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));



        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheSameArgument()
        {
            var math = new Math();

            var result = math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));




        }

    }
}
