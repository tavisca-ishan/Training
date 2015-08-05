using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserApplicationForm.Model;

namespace UserApplicationForm
{
    public partial class LoginUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("User Credentials");
            Credentials credentials = new Credentials();
            credentials.EmailId = TextBoxUserId.Text;
            credentials.Password = TextBoxPass.Text;
            HttpClient client = new HttpClient();
            var response = client.UploadData<Credentials, EmployeeResponse>("http://localhost:53412/EmployeeManagementService.svc/login", credentials);
            if (response.ResponseStatus.Code == "500")
            {
                Response.Write(response.ResponseStatus.Message);
            }
            else
            {
                cookie["EmpId"] = response.RequestedEmployee.Id;
                cookie["EmailId"] = response.RequestedEmployee.Email;
                cookie["Title"] = response.RequestedEmployee.Title;
                cookie["FirstName"] = response.RequestedEmployee.FirstName;
                Response.Cookies.Add(cookie);

                if (string.Equals(response.RequestedEmployee.Title.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                    Response.Redirect("http://localhost:51974/HRPage.aspx");

                else
                    Response.Redirect("http://localhost:51974/EmployeePage.aspx");
            }
        }
    }
}
