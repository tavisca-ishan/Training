using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserApplicationForm
{
    public partial class EmployeePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User Credentials"] != null)
            {
                 UserLabel.Text ="Hi"+" "+ Request.Cookies["User Credentials"]["FirstName"];
            }
        }

        protected void logoutUser(object sender, EventArgs e)
        {
             
             if (Request.Cookies["User Credentials"]!= null)
             {
                 HttpCookie cookie = new HttpCookie("User Credentials");
                 cookie.Expires = DateTime.Now.AddDays(-1d);
                 Response.Cookies.Add(cookie);
             }
             Response.Redirect("Login.aspx");
        }
    }
}