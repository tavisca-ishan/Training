
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAccess.Model
{
    public class EmployeeResponse : Result
    {
        public Employee RequestedEmployee { get; set; }
    }        
    
}