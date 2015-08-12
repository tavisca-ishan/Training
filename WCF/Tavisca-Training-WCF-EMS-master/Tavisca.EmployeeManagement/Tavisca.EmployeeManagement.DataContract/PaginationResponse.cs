﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.DataContract
{
        [DataContract]
        public class PaginationResponse : Result
        {
            [DataMember]
            public Pagination RequestedPagination { get; set; }
        }
    
}
