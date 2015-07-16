using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes.Testing
{
    [AttributeUsage(AttributeTargets.Method )]
    public class TestMethod : System.Attribute
    {
        
        public static bool Exists(MethodInfo type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is TestClass)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
