using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Server
    {
        private Listener _listener;
        private Dispatcher _dispatcher;
        public Server(string host, int port)
        {
            this._listener = new Listener(host, port);
            this._dispatcher = new Dispatcher();
        }
        public void Start()
        {
            Task.Factory.StartNew(() =>
                {
                    _dispatcher.Start();
                });
            Task.Factory.StartNew(() =>
                {
                    _listener.Listen();
                });
        }
        public void Stop()
        {
            _listener.Stop();
            _dispatcher.Stop();
        }
    }
}
