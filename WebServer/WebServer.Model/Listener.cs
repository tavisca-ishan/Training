using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    class Listener
    {
        private TcpListener _tcpListener;
        private bool _running=true;
        public Listener(string host,int port)
        {
            //listener start
            this._tcpListener=new TcpListener(IPAddress.Parse(host),port);
        }
        public void Listen()
        {
            this._tcpListener.Start(); //start listener
            while(this._running)
            {
                var socket=this._tcpListener.AcceptSocket(); //create client socket
                if((socket.Connected)==false)
                    continue;
                Application.RequestQueue.Enqueue(socket);
            }
        }
        public void Stop() 
        {
          this._running=false;
        }
}
}