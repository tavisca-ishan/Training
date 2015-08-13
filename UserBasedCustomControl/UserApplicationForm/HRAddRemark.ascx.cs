
using RoleBasedAccess.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserApplicationForm
{
    public partial class HRAddRemark : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                var response = GetAllEmployeeResponse.GetEmployeeList();
                List<Employee> allEmployeeList = null;
                allEmployeeList = response.RequestedEmployeeList;
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
               // allEmployeeList.Sort();

                //foreach (Employee employee in allEmployeeList)
                //{
                //    DDLSelectEmployee.DataTextField = employee.Id;
                //    DDLSelectEmployee.DataTextField = employee.FirstName;
                //    DDLSelectEmployee.DataTextField = employee.LastName;
                //    DDLSelectEmployee.DataValueField = employee.Id;
                //    DDLSelectEmployee.DataBind();
                //    //DDLSelectEmployee.Items.Add(new ListItem(allEmployeeList[employee.Id].ToString()));
                //}
                // DDLSelectEmployee.DataTextField=allEmployeeList.
                //    SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
                //    using (connect)
                //    {
                //        SqlCommand command = new SqlCommand("dropdown_emp", connect);
                //        command.CommandType = CommandType.StoredProcedure;
                //        connect.Open();
                //        DDLSelectEmployee.DataSource = command.ExecuteReader();
                //        DDLSelectEmployee.DataTextField = "emp_list";
                //        DDLSelectEmployee.DataValueField = "empId";
                //        DDLSelectEmployee.DataBind();
                //    }
                for (int i = 0; i < allEmployeeList.Count(); i++)
                {
                    Employee tempEmployee = allEmployeeList.ElementAt(i);
                    dictionary.Add(tempEmployee.Id.Trim(), tempEmployee.Id.Trim() + "." + tempEmployee.FirstName.Trim() + " " + tempEmployee.LastName.Trim());
                }
                DDLSelectEmployee.DataTextField = "Value";
                DDLSelectEmployee.DataValueField = "Key";
                DDLSelectEmployee.DataSource = dictionary;
                DDLSelectEmployee.DataBind();
                //  DDLSelectEmployee.Items.Insert(0, new ListItem("--Select Employee--", "0"));
                //}

            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Remark remark = new Remark();
            string employeeId = DDLSelectEmployee.DataValueField;
            remark.Text = TextAreaRemark.InnerText;
            remark.CreateTimeStamp = DateTime.UtcNow;
            var response = Remark.AddRemark(employeeId, remark);
            Response.Write(response.ResponseStatus.Message);
        }
    }
}