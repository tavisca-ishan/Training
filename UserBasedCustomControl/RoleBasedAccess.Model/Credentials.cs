using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAccess.Model
{
    public class Credentials
    {
        public string EmailId { get; set; }

        public string Password { get; set; }

        public static EmployeeResponse Authenticate(Credentials credentials)
        {
            EmployeeResponse response=null;
            try
            {
                HttpClient client = new HttpClient();
                string emsUrl = System.Configuration.ConfigurationManager.AppSettings["EmployeeManagementServiceUrl"];
                response = client.UploadData<Credentials, EmployeeResponse>(emsUrl + "/login", credentials);
            }
            catch(Exception)
            {
            }
            return response;
        }
    }
}