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
            set;
            get;
        }
        public double Amount
        {
            set;
            get;
        }

        //overload + operator to add two money objects

        public static Money operator +(Money first, Money second) //operator overloading
        {
            if ((first.Amount <= 0 || first.Amount > Double.MaxValue) || (second.Amount <= 0 || second.Amount > Double.MaxValue))
            {
                throw new System.Exception("Neither of the amounts can be null");

            }


            else
            {
                if (first.Currency.Equals(second.Currency))
                {
                    Money money = new Money();
                    money.Amount = first.Amount + second.Amount;
                    if (money.Amount < 0 || money.Amount > Double.MaxValue)
                    {
                        throw new System.Exception("Total Amount Exceeds The LImit");
                    }

                    else
                    {
                        return money;
                    }
                }
                else
                {
                    throw new System.Exception("Currency Mismatch Occurs");
                }
            }


        }


    }
}
    

