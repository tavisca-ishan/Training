using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApplicationForm.Model
{
    public class Pagination
    {
        public int Count { get; set; }

        public List<Remark> Remarks { get; set; }
    }

    public class PaginationResponse : Result
    {
        public Pagination RequestedPagination { get; set; }
    }
}