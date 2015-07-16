using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
 
namespace Tavisca.WCF.ServiceContract
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Add/{number1}/{number2}", ResponseFormat = WebMessageFormat.Json)]
        string AddNumbers(string number1, string number2);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Substract/{number1}/{number2}", ResponseFormat = WebMessageFormat.Json)]
        string SubstractNumbers(string number1, string number2);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate ="/Multiply/{number1}/{number2}", ResponseFormat = WebMessageFormat.Json)]
        string MultiplyNumbers(string number1, string number2);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Divide/{number1}/{number2}", ResponseFormat = WebMessageFormat.Json)]
        string DivideNumbers(string number1, string number2);
    }
}
