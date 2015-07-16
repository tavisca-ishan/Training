using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes.Testing
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestCategory:Attribute
    {
       
       private string _category;
       public string Category
       {
           get
           {
               return _category;
           }
       }
          public TestCategory(string testCategory)
         {
              _category=testCategory;
          }

          public static bool Exists(MethodInfo memberInfo, string category)
          {
              foreach (object attribute in memberInfo.GetCustomAttributes(true))
              {
                  if (attribute is TestCategory)
                  {
                      var attr = attribute as TestCategory;
                      if (attr.Category != null)
                          if(attr.Category.Equals(category, StringComparison.OrdinalIgnoreCase)) 
                              return true;
                  }
              }
              return false;
          }
    }
}
