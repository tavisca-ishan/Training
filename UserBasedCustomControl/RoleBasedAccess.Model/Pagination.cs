
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAccess.Model
{
    public class Pagination
    {
        public int Count { get; set; }

        public List<Remark> Remarks { get; set; }

        public static PaginationResponse GetPageRemarks(string employeeId,string pageNumber)
        {
            PaginationResponse response = null;
            try
            {
                HttpClient client = new HttpClient();
                string emsUrl = System.Configuration.ConfigurationManager.AppSettings["EmployeeServiceUrl"];
                response = client.GetData<PaginationResponse>(emsUrl + "/pagination/"+ employeeId+"/"+pageNumber);
            }
            catch (Exception)
            {
            }
            return response;
        }
    }

   
}