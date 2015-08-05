using Model;
using System;
using System.Collections.Generic;
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
                SqlConnection connect = new SqlConnection("Data Source=TRAINING11;Initial Catalog=WCFEmployee;Persist Security Info=True;User ID=sa;Password=test123!@#");
                using (connect)
                {
                    SqlCommand command = new SqlCommand("dropdown_emp", connect);
                    command.CommandType = CommandType.StoredProcedure;
                    connect.Open();
                    DDLSelectEmployee.DataSource = command.ExecuteReader();
                    DDLSelectEmployee.DataTextField = "emp_list";
                    DDLSelectEmployee.DataValueField = "empId";
                    DDLSelectEmployee.DataBind();
                }
                DDLSelectEmployee.Items.Insert(0, new ListItem("--Select Employee--", "0"));
            }

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Remark remark = new Remark();
            employee.Id = DDLSelectEmployee.Text;
            remark.Text = TextAreaRemark.InnerText;

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Remark));
            ser.WriteObject(stream1, remark);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            // Console.Write("JSON form of Person object: ");
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/employee/" + employee.Id + "/remark", "POST", d);
        }

      
    }
}