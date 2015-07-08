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
                Money moneyOne = new Money();   
                Money moneyTwo = new Money();   
                Money moneyThree = new Money();
                double result;
                Console.WriteLine("Enter currency and amount for first user");
                moneyOne.Currency=Console.ReadLine(); //recieve currency for first entry
                Double.TryParse(Console.ReadLine(), out result);   //recieve amount for first entry
                moneyOne.Amount =result;
             Console.WriteLine("Enter currency and amount for second user");
                  
                 moneyTwo.Currency=Console.ReadLine(); //recieve currency for second entry
                 Double.TryParse(Console.ReadLine(), out result);   //recieve amount for first entry
                 moneyTwo.Amount = result;
              
              moneyThree= moneyOne + moneyTwo;

                Console.WriteLine("Total Amount : {0} ", moneyThree.Amount); 
            }
           
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
           }//end of main
    }
}