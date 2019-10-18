using NUnit.Framework;
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
           
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));


        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max__WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
        

            var result = _math.Max(a,b);

            Assert.That(result, Is.EqualTo(expectedResult));

        }
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheSecondArgument()
        {
           

            var result = _math.Max(2, 1);

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
