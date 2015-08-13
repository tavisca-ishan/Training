
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAccess.Model
{
    public class RemarkResponse : Result
    {
        public Remark RequestedRemark { get; set; }
    }        
    
}