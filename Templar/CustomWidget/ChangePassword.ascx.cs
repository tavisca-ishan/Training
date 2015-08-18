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
    public partial class ChangePassword : System.Web.UI.UserControl,IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonPassword_Click(object sender, EventArgs e)
        {
            UpdatePassword change = new UpdatePassword();

            change.EmailId = Request.Cookies["User Credentials"]["emailid"];
            change.OldPassword = TextBoxOldPass.Text;
            change.NewPassword = TextBoxNewPass.Text;

            var response = UpdatePassword.ModifyPassword(change);
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