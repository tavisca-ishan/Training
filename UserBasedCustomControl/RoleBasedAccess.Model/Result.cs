using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAccess.Model
{
    public class Result
    {
        public Status ResponseStatus { get; set; }
        public Result()
        {
            this.ResponseStatus = Status.Success;
        }
    }
}