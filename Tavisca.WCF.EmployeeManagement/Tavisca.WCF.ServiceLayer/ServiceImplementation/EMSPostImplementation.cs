using ServiceLayer.Translator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tavisca.WCF.BusinessLayer.BusinessModel;
using Tavisca.WCF.ServiceLayer.DataContract;
using Tavisca.WCF.ServiceLayer.ServiceContract;


namespace Tavisca.WCF.ServiceLayer.ServiceImplementation
{
   
        public class EMSPostImplementation : IEmployeeManagementService
        {
            public Employee Create(Employee employee)
            {
                EmployeeModel employeeModel = Translator.EmployeeModelGenerator(employee);
                string employeeId = employeeModel.GenerateEmployeeId();
                employeeModel.Id = employeeId;
                EmployeeModel.InsertDetailsInFile(employeeModel);
                return employee;
            }

            public Remark AddRemark(string employeeId, Remark remark)
            {
                RemarkModel remarkModel = Translator.RemarkModelGenerator(remark);
                string timeStamp = remarkModel.GenerateDateTime();
                remarkModel.UtcTime =Convert.ToDateTime(timeStamp);
                RemarkModel.AddRemarkInFile(remarkModel, employeeId);
                return remark;
            }

        }
    
}
