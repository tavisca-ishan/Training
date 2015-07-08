using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{

    // do all validation in a private set property
    // create two constructors (double, string) and (string) 100 USD


    public class Money
    {

        private string _currency; //recieves currency
        private double _amount; //recieves amount
        double number;
        public Money(string newString)
        {
            string[] split = newString.Split(' ');
            if (split.Length != 2)
            {
                throw new System.Exception(ExceptionMessages.InvalidFormat);
            }
            if ((Double.TryParse(split[0], out number) != true))
            {
                throw new System.Exception(ExceptionMessages.InvalidFormat);
            }
        }

        public Money(string currency, double amount)
        {
            this.Currency = currency;
            this.Amount = amount;
        }

        public string Currency
        {
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new System.Exception(ExceptionMessages.CurrencyNull);
                }
                else
                {
                    _currency = value;
                }
            }
            get
            {
                return _currency;
            }
        }


        public double Amount
        {
            private set
            {
                if (value <= 0 || value > Double.MaxValue)
                {
                    throw new System.Exception(ExceptionMessages.AmountNull);
                }
                else
                {
                    _amount = value;
                }
            }

            get
            {
                return _amount;
            }


        }

        //overload + operator to add two money objects
        public static Money operator +(Money first, Money second) //operator overloading
        {

            if (String.Equals(first.Currency, second.Currency, StringComparison.InvariantCultureIgnoreCase))
            {
                double totalAmount = first.Amount + second.Amount;
                //Console.WriteLine("hie");
                      
               
                if (Double.IsPositiveInfinity(totalAmount))
                {
                    throw new System.Exception(ExceptionMessages.AmountExceeds);
                }

                else
                {
                    
                    return new Money(first.Currency, totalAmount);
                }
            }
            else
            {
                throw new Exception(ExceptionMessages.CurrencyMismatch);
            }
        }


    }


}



