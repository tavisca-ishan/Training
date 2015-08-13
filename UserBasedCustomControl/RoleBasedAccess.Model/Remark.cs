using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAccess.Model
{
    public class Remark
    {
        public string Text { get; set; }

        public DateTime CreateTimeStamp { get; set; }

        public static RemarkResponse AddRemark(string employeeId, Remark remark)
        {
            RemarkResponse response = null;
            try
            {
                HttpClient client = new HttpClient();
                string emsUrl = System.Configuration.ConfigurationManager.AppSettings["EmployeeManagementServiceUrl"];
                response = client.UploadData<Remark, RemarkResponse>(emsUrl +"/employee/"+employeeId+ "/remark", remark);
            }
            catch (Exception)
            {
            }
            return response;
        }
    }
}
