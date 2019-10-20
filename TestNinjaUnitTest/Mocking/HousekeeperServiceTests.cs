﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinjaUnitTest.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        private HousekeeperService _service;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _houseKeeper;

        [SetUp]
        public void SetUp()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _houseKeeper
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
            

            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
                 sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)));

        }
    }
}
