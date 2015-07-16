//using CustomAttributes.;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomAttributes.Testing;

namespace CustomAttributes.Model
{
    
    class Employee
    {
        [Ignore]
        public void DisplayName(string employeeName)
        {
            Console.WriteLine(employeeName);
        }
        [Ignore]
        public void DisplayAge(int employeeAge)
        {
            Console.WriteLine(employeeAge);
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        public void DisplaySalary(int employeeSalary)
        {
            Console.WriteLine(employeeSalary);
        }
    }
}
