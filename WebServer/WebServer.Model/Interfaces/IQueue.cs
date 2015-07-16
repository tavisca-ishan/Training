using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model.Interfaces
{
   public interface IQueue
    {
        bool TryDequeue(out Socket clientSocket);
        void Enqueue(Socket clientSocket);
    }
}
