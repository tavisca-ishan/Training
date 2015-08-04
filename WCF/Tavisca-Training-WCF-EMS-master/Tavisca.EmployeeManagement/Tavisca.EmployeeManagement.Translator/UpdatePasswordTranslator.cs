using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class UpdatePasswordTranslator
    {
        public static Model.UpdatePassword ToDomainModel(this DataContract.UpdatePassword change)
        {
            if (change == null) return null;
            return new Model.UpdatePassword()
            {
                EmailId = change.EmailId,
                OldPassword = change.OldPassword,
                NewPassword = change.NewPassword
            };
        }

        public static DataContract.UpdatePassword ToDataContract(this Model.UpdatePassword change)
        {
            if (change == null) return null;
            return new DataContract.UpdatePassword()
            {
                EmailId = change.EmailId,
                OldPassword = change.OldPassword,
                NewPassword = change.NewPassword
            };
        }
    }
}
