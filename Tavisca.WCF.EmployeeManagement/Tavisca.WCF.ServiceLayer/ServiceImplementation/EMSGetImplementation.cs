using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.WCF.BusinessLayer.BusinessModel;
using Tavisca.WCF.ServiceLayer.DataContract;
using Tavisca.WCF.ServiceLayer.ServiceContract;

namespace ServiceLayer.ServiceImplementation
{
    class EMSGetImplementation : IEmployeeService
    {
        public Employee Get(string id)
        {
            EmployeeModel employeeModel = EmployeeModel.GetEmployeeById(id);
            return Translator.TranslateToEmployee(employeeModel);
        }

        public List<Employee> GetAll()
        {

            List<EmployeeModel> employeeModelList = EmployeeModel.GetAll();

            return Translator.TranslateToEmployee(employeeModelList);

        }
    }
}


