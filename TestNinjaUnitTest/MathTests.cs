using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinjaUnitTest
{
    [TestFixture]
    class MathTests
    {
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

        }
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheSecondArgument()
        {


        }

    }
}
