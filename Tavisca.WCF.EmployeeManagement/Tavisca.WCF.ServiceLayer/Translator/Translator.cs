using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.WCF.BusinessLayer.BusinessModel;
using Tavisca.WCF.ServiceLayer.DataContract;

namespace ServiceLayer.Translator
{
    public class Translator
    {
        //performs mapping of service layer objects to business layer objects
        public static EmployeeModel EmployeeModelGenerator(Employee employee)
        {
            var employeeModel = EmployeeHandlerFactory.CreateInstance(employee.Title, employee.FirstName, employee.LastName, employee.EmailId);
            return employeeModel as EmployeeModel;
        }


        public static RemarkModel RemarkModelGenerator(Remark remark)
        {
            var remarkModel = RemarkHandlerFactory.CreateInstance(remark.RemarkText);
            return remarkModel as RemarkModel;
        }
        public static Employee TranslateToEmployee(EmployeeModel employeeModel)
        {
            Employee employeeDataContractObject = new Employee();
            employeeDataContractObject.Id = employeeModel.Id;
            employeeDataContractObject.Title = employeeModel.Title;
            employeeDataContractObject.FirstName = employeeModel.FirstName;
            employeeDataContractObject.LastName = employeeModel.LastName;
            employeeDataContractObject.Email = employeeModel.Remark;
            employeeDataContractObject.EmployeeRemark = employeeModel.Remark;

            return employeeDataContractObject;
        }
        public static List<Employee> TranslateToEmployee(List<EmployeeModel> allEmployeeDetails)
        {
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < allEmployeeDetails.Count - 1; i++)
            {
                Employee employeeDataContractObject = new Employee();
                employeeDataContractObject.Id = allEmployeeDetails[i].Id;
                employeeDataContractObject.Title = allEmployeeDetails[i].Title;
                employeeDataContractObject.FirstName = allEmployeeDetails[i].FirstName;
                employeeDataContractObject.LastName = allEmployeeDetails[i].LastName;
                employeeDataContractObject.Email = allEmployeeDetails[i].Remark;
                employeeDataContractObject.EmployeeRemark = allEmployeeDetails[i].Remark;
                employees.Add(employeeDataContractObject);
            }
            return employees;
        }
    }
}