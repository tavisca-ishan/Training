using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tavisca.WCF.BusinessLayer.BusinessModel;
using Tavisca.WCF.BusinessLayer.Interfaces;


namespace ServiceLayer.Translator
{
    public static class EmployeeHandlerFactory
    {
        //fetch employee object for employee details
        public static IEmployeeHandler CreateInstance(string title, string firstName, string lastName, string email)
        {
            var employeeHandler = new EmployeeModel(title, firstName, lastName, email);
            return employeeHandler;
        }
    }
}  