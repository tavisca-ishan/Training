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
            var response = client.UploadData<Credentials, Employee>("http://localhost:53412/EmployeeManagementService.svc/login", credentials);
            cookie["EmpId"] = response.Id;
            cookie["EmailId"] = response.Email;
            cookie["Title"] = response.Title;
            cookie["FirstName"] = response.FirstName;
            Response.Cookies.Add(cookie);
            if (response.Equals(null))
              Response.Write("Invalid User Credentials!");

            if (string.Equals(response.Title.Trim(),"hr",StringComparison.OrdinalIgnoreCase))
                Response.Redirect("http://localhost:51974/HRPage.aspx");

            else
                Response.Redirect("http://localhost:51974/EmployeePage.aspx");
        }
        }
    }
