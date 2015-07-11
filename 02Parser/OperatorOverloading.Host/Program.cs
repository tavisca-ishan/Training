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

                Money moneyOne = new Money(Console.ReadLine());//in format "100 USD"

                Console.WriteLine("Target Currency");

                string targetCurrency=Console.ReadLine();//in format "INR"
                

                double getexchangeRates1 = new Money().ConvertCurrency(moneyOne.Currency,targetCurrency);

                Console.WriteLine("Exchange Rates:One " + moneyOne.Currency + " equal to= " + getexchangeRates1 + " " + targetCurrency);

                Console.WriteLine("Converted Amount in " + targetCurrency + "= " + (getexchangeRates1 * moneyOne.Amount) + " " + targetCurrency);
            }//end of try block
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//end of catch block
            Console.ReadKey();


        }//end of main
    }//end of class
}//end of namespace
