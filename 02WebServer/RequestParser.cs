using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class RequestParser
    {
        private Encoding _charEncoder = Encoding.UTF8;
        public string HttpMethod;
        public string HttpUrl;
        public string HttpProtocolVersion;


        public void Parser(string requestString)
        {
            try
            {
                string[] token = requestString.Split(' ');
                Console.WriteLine(token.Length);
                token[1] = token[1].Replace("/", "\\");
                HttpMethod = token[0].ToUpper();
                HttpUrl = token[1];
                HttpProtocolVersion = token[2];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine("Bad Request");
            }
        }
    }
}
