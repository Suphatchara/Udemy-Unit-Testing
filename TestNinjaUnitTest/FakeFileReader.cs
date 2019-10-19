using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Mocking;

namespace TestNinjaUnitTest
{
    [TestClass]
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }

    }
    
}
