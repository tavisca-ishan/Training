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
    public partial class AddRemark : System.Web.UI.UserControl,IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
               
                var response = GetAllEmployeeResponse.GetEmployeeList();

                Dictionary<string, string> allEmployeeList = new Dictionary<string, string>();

                foreach (var employee in response.RequestedEmployeeList)
                {
                    if (employee.Title == "employee")
                    {
                        allEmployeeList.Add(employee.Id, (employee.Id + ". " + employee.FirstName + "  " + employee.LastName));

                    }
                }
                DDLSelectEmployee.DataSource = allEmployeeList;
                DDLSelectEmployee.DataTextField = "Value";
                DDLSelectEmployee.DataValueField = "Key";
               
                DDLSelectEmployee.DataBind();
            }
            DDLSelectEmployee.Items.Insert(0, new ListItem("--Select Employee--","0"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Remark remark = new Remark();
            string employeeId = DDLSelectEmployee.Text;
            remark.Text = TextAreaRemark.InnerText;
            remark.CreateTimeStamp = DateTime.UtcNow;
            var response = Remark.AddRemark(employeeId, remark);
            Response.Write(response.ResponseStatus.Message);
        }

        protected void DDLSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

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