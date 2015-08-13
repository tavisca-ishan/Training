﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAccess.Model
{
    public class GetAllEmployeeResponse :Result
    {
        public List<Employee> RequestedEmployeeList { get; set; }

        public static GetAllEmployeeResponse GetEmployeeList()
        {
            GetAllEmployeeResponse response=null;
            try
            {
                HttpClient client = new HttpClient();
                string emsUrl = System.Configuration.ConfigurationManager.AppSettings["EmployeeServiceUrl"];
                response = client.GetData<GetAllEmployeeResponse>(emsUrl + "/employee");
            }
            catch (Exception)
            {
            }
            return response;
        }
    }
}
