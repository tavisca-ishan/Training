using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace HTTP_Server
{
    public class Request
    {
        public String Type { get; set; }
        public String Url { get; set; }
        public String Host { get; set; }

        private Request(String type, String url, String host)//Request class cannot be instantiated from another class 
        {
        }
        public static Request GetRequest(String clientRequest)
        {
            if(String.IsNullOrEmpty(clientRequest))
            {
                //throw exception
            }
            String[] tokens=clientRequest.Split(' ');
            return new Request(" "," "," ");
        }
    }
}
