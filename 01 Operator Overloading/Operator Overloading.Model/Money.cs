using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_Overloading.Model
{
    public class Money
    {
         public string currency; //recieves currency
        public double amount;   //recieves amount
        //overload + operator to add two money objects
        public void getCurrency()          //to input currency from user
        {
            currency = Console.ReadLine();
            
        }
        public void getAmount()          //to input amount from user
        {
            

            amount = Convert.ToDouble(Console.ReadLine());
                if (amount<0)            //validating amount
                {
                    throw new ArgumentException("Amount cannot be negative");
                }
           
        }
         public static Money operator+(Money first,Money second) //operator overloading
                   { 
                        if(first.currency==second.currency)
                        {
                            Money money = new Money();
                            money.amount = first.amount + second.amount;
                            return money;
                        
                        }
                        else
                        {
                            throw new System.Exception("Enter Same currency");
                        }

                      
                   }
       
        
}
    }

