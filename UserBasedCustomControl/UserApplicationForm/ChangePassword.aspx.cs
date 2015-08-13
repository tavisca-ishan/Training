using RoleBasedAccess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UserApplicationForm
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdatePassword change = new UpdatePassword();

            change.EmailId = Request.Cookies["User Credentials"]["emailid"];
            change.OldPassword = TextBoxOldPass.Text;
            change.NewPassword = TextBoxNewPass.Text;

            var response = UpdatePassword.ModifyPassword(change);
            Response.Write(response.ResponseStatus.Message);
           
        }
        protected void TextBoxUserId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}