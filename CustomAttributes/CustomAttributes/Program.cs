using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CustomAttributes.Model;
using CustomAttributes.Testing;

namespace CustomAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the test category");
            var category = Console.ReadLine();
            Assembly assembly = Assembly.LoadFrom(args[0]);

            var ignoreMethods = new List<string>();
            var executableMethods = new List<string>();
            foreach (Type type in assembly.GetTypes())
            {
                  if (type.IsClass && TestClass.Exists(type))
                {
                    foreach (MethodInfo method in (type.GetMethods()))
                    {
                        if (TestMethod.Exists(method))
                        {
                            if (Ignore.Exists(method))
                                ignoreMethods.Add(method.Name);

                            else if (string.IsNullOrWhiteSpace(category) || TestCategory.Exists(method, category))
                                executableMethods.Add(method.Name);
                        }
                    }
                }
            }
            Console.WriteLine("Ignore Methods are");
            foreach (string showIgnore in ignoreMethods)
            {
                Console.WriteLine(showIgnore);
            }
            Console.WriteLine("Executable Methods are");
            foreach (string showExecutable in executableMethods)
            {
                Console.WriteLine(showExecutable);
            }
            Console.ReadKey();
        }

    }
}