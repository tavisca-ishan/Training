using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer
{
    class Listener
    {
        private Socket _serverSocket;
        private int _timeout;
        private string _contentPath;
        private Encoding _charEncoder = Encoding.UTF8;

        public Listener(Socket serverSocket, String contentPath)
        {
            _serverSocket = serverSocket;
            _timeout = 5;
            _contentPath = contentPath;
        }

        public void AcceptRequest()
        {
            Socket clientSocket = null;
            try
            {
                // Create new thread to handle the request and continue to listen the socket.
                clientSocket = _serverSocket.Accept();
                var requestHandler = new Thread(() =>
                {
                    clientSocket.ReceiveTimeout = _timeout;
                    clientSocket.SendTimeout = _timeout;
                    HandleTheRequest(clientSocket);
                });
                requestHandler.Start(); //starting the client thread
            }
            catch
            {
                Console.WriteLine("Error!Cannot connect to client");
                Console.ReadLine();
                if (clientSocket != null)
                    clientSocket.Close();
            }
        }

        private void HandleTheRequest(Socket clientSocket)
        {
            var requestParser = new RequestParser();
            string requestString = DecodeRequest(clientSocket);
            //Console.WriteLine(requestString);
            requestParser.Parser(requestString);

            if (requestParser.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                var processor = new Processor(clientSocket, _contentPath);
                processor.RequestUrl(requestParser.HttpUrl);
            }
            else
            {
                Console.WriteLine("unimplimented method");
                Console.ReadLine();
            }
            StopClientSocket(clientSocket);
        }

        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
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
                //Console.WriteLine("buffer full");
                Console.ReadLine();
            }

            return _charEncoder.GetString(buffer, 0, receivedBufferlen);
        }
    }
}
