using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using RoleBasedAccess.Model;

namespace UserApplicationForm
{
    public partial class HRAddEmployee : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Title = TextBoxTitle.Text;
            employee.FirstName = TextBoxFN.Text;
            employee.LastName = TextBoxLN.Text;
            employee.Email = TextBoxEmail.Text;
            employee.Phone = TextBoxPhone.Text;
            employee.Password = TextBoxPass.Text;

            var response = Employee.AddEmployee(employee);
            Response.Write(response.ResponseStatus.Message);
        }
    }
}