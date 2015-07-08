using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {

        private string currency; //recieves currency
        private double amount; //recieves amount
        public string Currency
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new System.Exception(ExceptionMessages.CurrencyNull);
                }
                else
                {
                    currency = value;
                }
            }
            get { return currency; }
        }
        public double Amount
        {
            set
            {
              amount = value;
            }
            
            get
            {
                return amount;
            }  
           
        
         }

        //overload + operator to add two money objects

        public static Money operator +(Money first, Money second) //operator overloading
        {
          


           
                if (String.Equals(first.Currency, second.Currency, StringComparison.InvariantCultureIgnoreCase))
                {
                    Money money = new Money();
                    money.Amount = first.Amount + second.Amount;
                    if (money.Amount < 0 || money.Amount > Double.MaxValue)
                    {
                        throw new System.Exception(ExceptionMessages.AmountExceeds);
                    }

                    else
                    {
                        return money;
                    }
                }
                else
                {
                    throw new System.Exception(ExceptionMessages.CurrencyMismatch);
                }
            }


        }


    }

    

