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
        public static void Main(string[] args)
        {
            
                double result1;
                double result2;
                Console.WriteLine("Enter currency and amount for first entry");
                string currency1 = Console.ReadLine();
                Double.TryParse(Console.ReadLine(), out result1);
                Money moneyOne = new Money(currency1, result1);
                Console.WriteLine("Enter currency and amount for second entry");
                string currency2 = Console.ReadLine();
                Double.TryParse(Console.ReadLine(), out result2);

                Money moneyTwo = new Money(currency2, result2);
                Money moneyThree;

              try{
                    moneyThree = moneyOne + moneyTwo;
            }


            catch (Exception e)
            {
                Console.WriteLine("hie"+e.Message);
                Console.ReadKey();
                return;
            }
              Console.WriteLine("Currency and Total Amount : {0} ", moneyThree.Currency, moneyThree.Amount);
            Console.ReadKey();
        }//end of main
    }
}