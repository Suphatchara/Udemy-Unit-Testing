using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class FileDownloader

    {
        public void DownloadFile(string url, string path)
        {
            var client = new IWebClient();
            client.DownloadFile(url, path);

                   
        }

    }
}
