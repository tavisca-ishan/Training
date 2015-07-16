using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    class Dispatcher
    {

        private bool _running = true;
        public void Start()
        {
            while (this._running)
            {
                Socket clientSocket;
                if (Application.RequestQueue.TryDequeue(out clientSocket) == false)
                    continue;
                Task.Factory.StartNew(() =>
                 {
                     this.Dispatch(clientSocket);
                 });
                
            }
        }
        private void Dispatch(Socket clientSocket)
        {
            var requestParser = new RequestParser();
            string requestString = DecodeRequest(clientSocket);
            
            requestParser.Parser(requestString);

            if (requestParser.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                var processor = new Processor(clientSocket, ConfigurationManager.AppSettings["virtual directory"]);
                processor.RequestUrl(requestParser.HttpUrl);
            }
            else
            {
                Console.WriteLine("Unimplimented Method");
                Console.ReadLine();
            }
            StopClientSocket(clientSocket);
        }
        private string DecodeRequest(Socket clientSocket)
        {
            var receivedBufferlen = 0;
            var buffer = new byte[10240];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)
            {
                Console.WriteLine("buffer full");
                Console.ReadLine();
            }

            return Encoding.UTF8.GetString(buffer, 0, receivedBufferlen);
        }
        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
        }
        public void Stop()
        {
            _running = false;
        }

     }
}