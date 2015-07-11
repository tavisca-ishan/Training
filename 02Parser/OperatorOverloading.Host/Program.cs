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

                Money moneyTwo = new Money(Console.ReadLine());//in format "INR"

                double getexchangeRates1 = new Money().ConvertCurrency(moneyOne.Currency, moneyTwo.Currency);

                Console.WriteLine("Exchange Rates:One " + moneyOne.Currency + " equal to= " + getexchangeRates1 + " " + moneyTwo.Currency);

                Console.WriteLine("Converted Amount in " + moneyTwo.Currency + "= " + (getexchangeRates1 * moneyOne.Amount) + " " + moneyTwo.Currency);
            }//end of try block
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//end of catch block
            Console.ReadKey();


        }//end of main
    }//end of class
}//end of namespace
