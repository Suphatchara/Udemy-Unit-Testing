﻿using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;
namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private HousekeeperService _service;
        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _houseKeeper;
        private string _statementFileName;

        [SetUp]
        public void Setup()
        {
            _houseKeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _houseKeeper
            }.AsQueryable());

            _statementFileName = "fileName";
            _statementGenerator = new Mock<IStatementGenerator>();
            _statementGenerator
                .Setup(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)))
                 .Returns(() => _statementFileName);
           
            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();
           
            _service = new HousekeeperService(
                unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object);
        }
        [Test]
        public void SendStatmentEmails_WhenCalled_GenerateStatements()
        {
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)));
        }
        [Test]
        public void SendStatmentEmail_HouseKeepersEmailsNull_ShouldNotGenerateStatements()
        {
            _houseKeeper.Email = null;
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)),
            Times.Never);
        }
        [Test]
        public void SendStatmentEmail_HouseKeepersEmailsWhitespace_ShouldNotGenerateStatements()
        {
            
            _houseKeeper.Email = " ";
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)),
            Times.Never);
        }
        [Test]
        public void SendStatmentEmail_HouseKeepersEmailsEmpty_ShouldNotGenerateStatements()
        {
            _houseKeeper.Email = " ";
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)),
            Times.Never);
        }
        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _service.SendStatementEmails(_statementDate);

            VerifyEmailSent();
        }


        [Test]
        public void SendStatmentEmail_StatementFileNameIsNull_ShouldNotEmailTheStatement()
        {

            _statementFileName = null;
            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();

        }


        [Test]
        public void SendStatmentEmail_StatementFileNameIsEmptyString_ShouldNotEmailTheStatement()
        {
            _statementFileName = "";
            _service.SendStatementEmails(_statementDate);
            VerifyEmailNotSent();
        }
        [Test]
        public void SendStatmentEmail_StatementFileNameIsWhitespace_ShouldNotEmailTheStatement()
        {
            _statementFileName = "";
            _service.SendStatementEmails(_statementDate);
            VerifyEmailNotSent();

        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            _emailSender.Setup(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
            )).Throws<Exception>();

            _service.SendStatementEmails(_statementDate);

            _messageBox.Verify(mb => mb.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
        }

            private void VerifyEmailNotSent()
            {
            _emailSender.Verify(es => es.EmailFile(
                            It.IsAny<string>(),
                            It.IsAny<string>(),
                            It.IsAny<string>(),
                            It.IsAny<string>()),
                            Times.Never);
            }


        private void VerifyEmailSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                _houseKeeper.Email,
                _houseKeeper.StatementEmailBody,
                _statementFileName,
                It.IsAny<string>()));
        }
    }
}