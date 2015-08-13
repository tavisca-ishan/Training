using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAccess.Model
{
    public class Employee
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public DateTime JoiningDate { get; set; }

        public List<Remark> Remarks { get; set; }

        public static EmployeeResponse AddEmployee(Employee employee)
        {
            EmployeeResponse response=null;
            try
            {
                HttpClient client = new HttpClient();
                string emsUrl = System.Configuration.ConfigurationManager.AppSettings["EmployeeManagementServiceUrl"];
                response = client.UploadData<Employee, EmployeeResponse>(emsUrl + "/employee", employee);
            }
            catch(Exception)
            {
            }
            return response;

        }



    }
}
