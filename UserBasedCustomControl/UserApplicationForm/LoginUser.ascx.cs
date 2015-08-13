using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using RoleBasedAccess.Model;

namespace UserApplicationForm
{
    public partial class LoginUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            HttpCookie cookie1 = new HttpCookie("User Credentials");
            Credentials credentials = new Credentials();
            credentials.EmailId = TextBoxUserId.Text;
            credentials.Password = TextBoxPass.Text;

            EmployeeResponse response = Credentials.Authenticate(credentials);
            if (response.ResponseStatus.Code == "500")
            {
                Response.Write(response.ResponseStatus.Message);
               
            }
            else
            {
                cookie1["empid"] = response.RequestedEmployee.Id;
                cookie1["emailid"] = response.RequestedEmployee.Email;
                cookie1["title"] = response.RequestedEmployee.Title;
                cookie1["firstname"] = response.RequestedEmployee.FirstName;
                FormsAuthentication.Initialize();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,response.RequestedEmployee.Email,DateTime.UtcNow,DateTime.Now.AddMinutes(10),false,response.RequestedEmployee.Title,FormsAuthentication.FormsCookiePath);

                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie( FormsAuthentication.FormsCookieName,hash); 
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie1);

                if (string.Equals(response.RequestedEmployee.Title.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                    Response.Redirect("http://localhost:51974/HRPage.aspx");

                else
                    Response.Redirect("http://localhost:51974/EmployeePage.aspx");
            }
        }
    }
}
