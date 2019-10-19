﻿using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaUnitTest.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

        }
    }


}
