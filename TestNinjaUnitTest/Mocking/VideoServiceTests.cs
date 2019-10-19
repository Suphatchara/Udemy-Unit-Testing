using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinjaUnitTest.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
       
        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>()
            _videoService = new VideoService(_fileReader.Object, _repository.Object);
        }
    }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);

        }
}
