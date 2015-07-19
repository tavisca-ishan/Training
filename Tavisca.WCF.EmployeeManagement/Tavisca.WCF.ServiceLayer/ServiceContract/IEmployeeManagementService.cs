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
    [ServiceContract]
        public interface IEmployeeManagementService
        {
            [OperationContract]
            [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "employeeId/title/firstName/lastName/emailId")]
            Employee Create(Employee employee);
            [OperationContract]
            [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "employeId/Remark")]
            Remark AddRemark(string employeeId, Remark remark);
        }
    }