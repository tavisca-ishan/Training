using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes.Testing
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClass : System.Attribute
    {
        public TestClass()
        {
        }

        public static bool Exists(Type type)
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
