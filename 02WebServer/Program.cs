using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string contentPath=ConfigurationManager.AppSettings["contentPath"];
            HttpServer server = new HttpServer();
            server.Start(8080,contentPath);
        }
    }
}
