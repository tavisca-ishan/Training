using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tavisca.WCF.ServiceLayer.DataContract;

namespace Tavisca.WCF.ServiceLayer.ServiceContract
{
    interface IEmployeeService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "employeeId/title/firstName/lastName/emailId")]
        Employee Get(string employeeId);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "employeeId/title/firstName/lastName/emailId")]
        List<Employee> GetAll();
    }
}
