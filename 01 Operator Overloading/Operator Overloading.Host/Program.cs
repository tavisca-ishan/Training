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
            try
            {
                Console.WriteLine("Enter amount and currency for first entry");
                Money moneyOne = new Money(Console.ReadLine());

                Console.WriteLine("Enter amount and currency for second entry");
               


                Money moneyTwo = new Money( Console.ReadLine());
                Money moneyThree = moneyOne + moneyTwo;
                Console.WriteLine("Currency and Total Amount : {0} {1}",  moneyThree.Amount,moneyThree.Currency);

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }//end of main
    }
}