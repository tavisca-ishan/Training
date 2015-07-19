using DataContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation
{
   public class EMSPostImplementation :IEmployeeManagementService
    {
       public Employee Create(Employee employee)
       {
           var employeeInfo = new Employee();
           employeeInfo = employee;
           return employeeInfo;
       }
       public Remark AddRemark(string employeeId, Remark remark)
       {
           var remarkInfo = new Remark();
           remarkInfo = remark;
           return remarkInfo;
       }

    }
}
