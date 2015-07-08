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
                moneyOne.Currency = Console.ReadLine();           //recieve currency for first entry
                                   
                
                    if (Double.TryParse( Console.ReadLine(), out result) == true) //it returns false also when entered amount is null or empty
                    {
                        moneyOne.Amount = result;
                    }
                    else
                    {
                        throw new System.Exception();
                    }
                
                  
                
             Console.WriteLine("Enter currency and amount for second user");
                  
                 moneyTwo.Currency=Console.ReadLine();              //recieve currency for second entry
                 if (Double.TryParse(Console.ReadLine(), out result) == true) //it returns false also when entered amount is null or empty
                    {
                      moneyOne.Amount = result;
                    }
                   
                 else
                    {
                        throw new System.Exception(ExceptionMessages.AmountNull);          
                    }
                
                 
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