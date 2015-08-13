﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAccess.Model
{
    public class Status
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public static Status Success { get { return new Status() { Code = "200", Message = "Success" }; } }
    }
}