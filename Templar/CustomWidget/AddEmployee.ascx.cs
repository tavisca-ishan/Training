using RoleBasedAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace CustomWidget
{
    public partial class AddEmployee : System.Web.UI.UserControl,IWidget
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
            employee.JoiningDate = DateTime.UtcNow;
            var response = Employee.AddEmployee(employee);
            Response.Write(response.ResponseStatus.Message);
        }


        public void HideSettings()
        {
            //throw new NotImplementedException();
        }

        public new void Init(IWidgetHost host)
        {
            //throw new NotImplementedException();
        }

        public void ShowSettings()
        {
            //throw new NotImplementedException();
        }
    }
}