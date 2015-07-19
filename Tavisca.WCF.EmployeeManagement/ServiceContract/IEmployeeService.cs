using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceContract
{
    interface IEmployeeService
    {
        [OperationContract]
        Employee Get(string employeeId);
        [OperationContract]
        List<Employee> GetAll();         
    }
}
