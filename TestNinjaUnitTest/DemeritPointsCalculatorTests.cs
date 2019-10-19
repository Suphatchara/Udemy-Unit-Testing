using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinjaUnitTest
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        public void CalculateDemeritPoints_SpeedIsNegative_ThrowArgumentOurOfRangeException()
        {

        } 

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_SpeedIsLessThanOrEqualToSpeedLimit_ReturnZero(int speed)
        {

        }

      

    }
}
