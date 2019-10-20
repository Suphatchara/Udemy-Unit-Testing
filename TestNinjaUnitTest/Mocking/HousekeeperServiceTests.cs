﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using Moq;

namespace TestNinjaUnitTest.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        private ReHouseKeeperHelper _service;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;

        [SetUp]
        public void SetUp()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                new Housekeeper {Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" }
            }.AsQueryable());
            _statementGenerator = new Mock<IStatementGenerator>();
            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();


            _service = new HousekeeperService(
                  unitOfWork.Object,
                  _statementGenerator.Object,
                  _emailSender.Object,
                  _messageBox.Object);



        }
        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            

            _service.SendStatementEmails(new DateTime(2017, 1, 1));
            _statementGenerator.Verify(sg => sg.SaveStatement(1, "b", (new DateTime(2017, 1, 1))));

        }
    }
}
