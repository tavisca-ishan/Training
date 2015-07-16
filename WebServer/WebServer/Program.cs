using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;
namespace WebServer.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string host = ConfigurationManager.AppSettings["webserver-host"];
                if (string.IsNullOrEmpty(host))
                    throw new System.Exception();

                int port = 0;
                if (int.TryParse(ConfigurationManager.AppSettings["webserver-port"], out port) == false)
                    throw new System.Exception("Cannot Identify Port!Invalid Port")

                Server server = new Server(host, port);

                server.Start();
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                server.Stop();
            }

                
            
            catch(Exception e) 
            {
                Console.WriteLine("Cannot Identify Host!Invalid Host");
            }
                
        }
    }
}
