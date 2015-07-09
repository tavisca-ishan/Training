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
               // double result1;
                //double result2;
                Console.WriteLine("Enter amount and currency for first entry");
                string input1 = Console.ReadLine();
               
                Money moneyOne = new Money(input1);
              
                Console.WriteLine("Enter amount and currency for second entry");
                string input2 = Console.ReadLine();
                

                Money moneyTwo = new Money(input2);
                Money moneyThree;

                    moneyThree = moneyOne + moneyTwo;
                    Console.WriteLine("Currency and Total Amount : {0} ", moneyThree.Currency, moneyThree.Amount);

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            Console.ReadKey();
        }//end of main
    }
}