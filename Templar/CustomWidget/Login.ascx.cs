using RoleBasedAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace CustomWidget
{
    public partial class Login : System.Web.UI.UserControl,IWidget
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
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, response.RequestedEmployee.Email, DateTime.UtcNow, DateTime.Now.AddMinutes(10), false, response.RequestedEmployee.Title, FormsAuthentication.FormsCookiePath);

                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie1);

                if (string.Equals(response.RequestedEmployee.Title.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                    Response.Redirect("HRPage");

                else
                    Response.Redirect("EmployeePage");
            }
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