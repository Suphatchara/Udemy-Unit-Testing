﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTest
{
    [TestFixture]
    class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

          
            Assert.That(result, Is.TypeOf<NotFound>());

          
            Assert.That(result, Is.InstanceOf<NotFound>());




        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnOk()
        {

        }
    }
}
