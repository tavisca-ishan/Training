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

                Money money1 = new Money(Console.ReadLine());//in format "100 USD"

                Console.WriteLine("Target Currency");

                Money money2 = new Money(Console.ReadLine());//in format "INR"

                double getexchangeRates1 = new Money().ConvertCurrency(money1.Currency, money2.Currency);

                Console.WriteLine("Exchange Rates:One " + money1.Currency + " equal to= " + getexchangeRates1 + " " + money2.Currency);

                Console.WriteLine("Converted Amount in " + money2.Currency + "= " + (getexchangeRates1 * money1.Amount) + " " + money2.Currency);
            }//end of try block
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//end of catch block

            Console.ReadKey();


        }//end of main
    }//end of class
}//end of namespace
