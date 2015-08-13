
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAccess.Model
{
    public class PaginationResponse : Result
    {
        public Pagination RequestedPagination { get; set; }
    }
   
}