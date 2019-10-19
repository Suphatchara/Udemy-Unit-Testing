using System;
using Moq;
using TestNinja.Mocking;
using NUnit.Framework;

namespace TestNinjaUnitTest.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
        }

    }
}
