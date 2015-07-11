using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace HTTP_Server
{
   public class Dispatcher
    {
       public void ClientHandler(TcpClient recieveRequest)
       {
           string fileData = " ";
           string line;
           StreamReader readFile = new StreamReader(recieveRequest.GetStream());

           while ((line = readFile.ReadLine()) != null)
           {
               fileData += line;
           }
           readFile.Close();
       }

    }
}
