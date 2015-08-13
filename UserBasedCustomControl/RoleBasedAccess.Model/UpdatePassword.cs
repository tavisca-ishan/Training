using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAccess.Model
{
    public class UpdatePassword
    {
        public string EmailId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public static UpdatePasswordResponse ModifyPassword(UpdatePassword change)
        {
            UpdatePasswordResponse response = null;
            try
            {
                HttpClient client = new HttpClient();
                string emsUrl = System.Configuration.ConfigurationManager.AppSettings["EmployeeManagementServiceUrl"];
                response = client.UploadData<UpdatePassword, UpdatePasswordResponse>(emsUrl + "/changePassword", change);
            }
            catch (Exception)
            {
            }
            return response;
        }
    }
}