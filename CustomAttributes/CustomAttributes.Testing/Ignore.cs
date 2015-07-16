using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes.Testing
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Ignore :Attribute
    {

        public static bool Exists(MethodInfo type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is Ignore)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
