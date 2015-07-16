using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClient.ClientReference;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorClient proxy = new CalculatorClient();
            double addResult = proxy.AddNumbers(9, 3);
            Console.WriteLine("Result of Add Operation");
            Console.WriteLine(addResult);


            double subResult = proxy.SubstractNumbers(9, 3);
            Console.WriteLine("Result of Substract Operation");
            Console.WriteLine(subResult);

            double mulResult = proxy.MultiplyNumbers(9, 3);
            Console.WriteLine("Result of Multiply Operation");
            Console.WriteLine(mulResult);

            double divResult = proxy.DivideNumbers(9, 3);
            Console.WriteLine("Result of Division Operation");
            Console.WriteLine(divResult);

            Console.ReadKey();
        }
    }
}
