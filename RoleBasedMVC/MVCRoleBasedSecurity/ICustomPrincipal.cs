using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRoleBasedSecurity
{
    public interface ICustomPrincipal : System.Security.Principal.IPrincipal
    {
        string Id { get; set; }

        string Title { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string EmailId { get; set; }
        string Password { get; set; }
    }
}