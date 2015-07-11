using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Server
{
    public class WebServer
    {
        private int port;
        Boolean running = false;
        private TcpListener listen;
        public WebServer(int port)
        {
            listen = new TcpListener(IPAddress.Any, 8080);
        }
      public void Start() //where is Start() called?
        {
            Thread serverThread = new Thread(new ThreadStart(Run));
            serverThread.Start(); //to start the thread
        }
        public void Run()
        {
            running = true;    //port made active 
            listen.Start();  //to activate the listener(function of listener class)
            while (running)
            {
                Console.WriteLine("Connecting....");
                TcpClient client = listen.AcceptTcpClient();
                Console.WriteLine("Connected with Client");
                Dispatcher dispatch = new Dispatcher();
                dispatch.ClientHandler(client);
                client.Close();

            }
            running = false;
            listen.Stop();
        }
    }
}
