using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;


namespace OperatorOverloading.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Performing Currency Conversion");
                Console.WriteLine("Enter Amount to be converted and Source Currency");

                var moneyOne = new Money(Console.ReadLine());//in format "100 USD"

                Console.WriteLine("Enter Target Currency");

                string targetCurrency = Console.ReadLine();//in format "INR"

                var getexchangeRates1 = moneyOne.Convert(targetCurrency);

                Console.WriteLine("Converted Amount in " + targetCurrency + "= " + moneyOne.Amount + " " + targetCurrency);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}