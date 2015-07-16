susing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webserver.Model;
using WebServer.Model.Interfaces;

namespace WebServer.Model
{
    internal class Application
    {
         static Application()
        {
            RequestQueue = new InProcedureQueue();
        }
        public static IQueue RequestQueue { get; private set; }
    }
    }

