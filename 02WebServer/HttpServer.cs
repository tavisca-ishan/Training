﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class HttpServer
    {
        // check for already running
        private bool _running = false;
        private int _timeout = 5;
        private Encoding _charEncoder = Encoding.UTF8;
        private Socket _serverSocket;

        // to store the path of our contents
        private string _contentPath;

        //create socket and initialization
        private void InitializeSocket(int port, string contentPath) //create socket
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            _serverSocket.Listen(10);    
            _serverSocket.ReceiveTimeout = _timeout;
            _serverSocket.SendTimeout = _timeout;
            _running = true; //socket created
            _contentPath = contentPath;
        }
        public void Start(int port, string contentPath)
        {
            try
            {
                InitializeSocket(port, contentPath);
            }
            catch
            {
                Console.WriteLine("Error!Server Socket cannot be created");
                Console.ReadKey();
            }
            while (_running)
            {
                var listener = new Listener(_serverSocket, contentPath);
                listener.AcceptRequest();
            }
        }
        public void Stop()
        {
            _running = false;
            try
            {
                _serverSocket.Close();
            }
            catch
            {
                Console.WriteLine("Error in closing server or server already closed");
                Console.ReadKey();

            }
            _serverSocket = null;
        }

    }
}
