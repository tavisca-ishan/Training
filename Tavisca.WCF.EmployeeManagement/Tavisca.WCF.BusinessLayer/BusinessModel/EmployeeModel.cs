using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.WCF.BusinessLayer.Interfaces;
using Microsoft.JScript;
using Tavisca.WCF.DataAccessLayer;
using Newtonsoft.Json;             

           
namespace Tavisca.WCF.BusinessLayer.BusinessModel
{
   public class EmployeeModel : IEmployeeHandler
    { 
       //entering employee details
       public string Id { get; set; }
       public string Title { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Email { get; set; }
       public string Remark { get; set; }

       public EmployeeModel(string title, string firstName, string lastName, string email)
       {
           this.Id = "";
           this.Title = title;
           this.FirstName = firstName;
           this.LastName = lastName;
           this.Email = email;
       }
       //generate random id
       public string GenerateEmployeeId()
       {
           string employeeId = string.Format(@"{0}", Guid.NewGuid());
           return employeeId;
       }
       //enter employee details in dictionary and then file
       
       public static void InsertDetailsInFile(EmployeeModel employee)
       {
           var json = JsonConvert.SerializeObject(employee);
           FileSystem file = new FileSystem();
           file.SaveEmployee(json,employee.Id);
       }
       public static EmployeeModel GetEmployeeById(string id) //deserialize the jsonstring recieved by getDetailsById()
       {
           FileSystem file = new FileSystem();
           EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(file.getDetailsById(id));
           return employeeModel;
       }

       //get all details of all employees
       public static List<EmployeeModel> GetAll()
       {
           List<EmployeeModel> allEmployeeDetails = new List<EmployeeModel>();
           FileSystem getAllfiles = new FileSystem();
           List<string> allEmployeeId = getAllfiles.GetAllIds();
           for (int counter = 0; counter < allEmployeeId.Count-1; counter++)
           {
              allEmployeeDetails.Add(GetEmployeeById(allEmployeeId[counter]));
           }
         return allEmployeeDetails;
       }


    }
}
