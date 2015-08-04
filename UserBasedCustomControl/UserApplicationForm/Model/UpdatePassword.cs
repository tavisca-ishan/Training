using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApplicationForm.Model
{
    public class UpdatePassword
    {
        public string EmailId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}