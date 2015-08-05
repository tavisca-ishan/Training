using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApplicationForm.Model
{
    public class UpdatePasswordResponse : Result
    {

        public UpdatePassword RequestedUpdatePassword { get; set; }
    }
}