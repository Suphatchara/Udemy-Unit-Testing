using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTest
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        public void CalculateDemeritPoints_SpeedIsNegative_ThrowArgumentOurOfRangeException()
        {
            var calculator = new DemeritPointsCalculator();

            calculator.CalculateDemeritPoints(-1);

        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsOver300_ThrowArgumentOurOfRangeException()
        {

        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoint(int speed)
        {

        }

      

    }
}
