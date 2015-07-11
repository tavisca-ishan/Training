using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace HTTP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to server at port number 8080");
            WebServer server = new WebServer(8080);
            server.Start();   
        }
    }
}
