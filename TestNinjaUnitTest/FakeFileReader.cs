using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Mocking;

namespace TestNinjaUnitTest
{
  
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }

    }
    
}
