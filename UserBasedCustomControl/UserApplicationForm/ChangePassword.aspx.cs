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

            change.EmailId = Request.Cookies["User Credentials"]["EmailId"];
            change.OldPassword = TextBoxOldPass.Text;
            change.NewPassword = TextBoxNewPass.Text;

            //MemoryStream stream1 = new MemoryStream();
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UpdatePassword));
            //ser.WriteObject(stream1, change);
            //stream1.Position = 0;
            //StreamReader sr = new StreamReader(stream1);
            //// Console.Write("JSON form of Person object: ");
            //string d = sr.ReadToEnd();
            //var client = new WebClient();
            //client.Headers.Add("Content-Type", "application/json");
            HttpClient client = new HttpClient();
            var response = client.UploadData<UpdatePassword, UpdatePasswordResponse>("http://localhost:53412/EmployeeManagementService.svc/changepassword", change);
            if (response.ResponseStatus.Code == "500")
                Response.Write(response.ResponseStatus.Message);
        }
        protected void TextBoxUserId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}