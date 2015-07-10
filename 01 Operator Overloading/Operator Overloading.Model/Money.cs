using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private string _currency; //recieves currency
        private double _amount; //recieves amount


        /// <summary>
        /// 
        /// </summary>
        /// <param name="moneyString">Money represented as string eg 100 USD</param>
        public Money(string moneyString)
        {
            if (moneyString == null)
            {
                throw new System.Exception(ExceptionMessages.NullEntered);
            }
            string[] split = moneyString.Split(' ');
            if (split.Length != 2)
            {
                throw new System.Exception(ExceptionMessages.InvalidFormat);
            }

            double amount;
            if ((double.TryParse(split[0], out amount) == false))
            {
                throw new System.Exception(ExceptionMessages.InvalidFormat);
            }

            Amount = amount;
            Currency = split[1];

        }

        public Money(double amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public string Currency
        {
            private set
            {
                if (string.IsNullOrEmpty(value))

                    throw new System.Exception(ExceptionMessages.CurrencyNull);

                _currency = value;

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
                if (value <= 0 || value > double.MaxValue)

                    throw new System.Exception(ExceptionMessages.AmountNull);

                _amount = value;

            }

            get
            {
                return _amount;
            }

        }

        //overload + operator to add two money objects
        public static Money operator +(Money money1, Money money2) //operator overloading
        {
            if (money1 == null || money2 == null)

                throw new System.Exception(ExceptionMessages.AmountNull);

            if (string.Equals(money1.Currency, money2.Currency, StringComparison.InvariantCultureIgnoreCase) == false)

                throw new Exception(ExceptionMessages.CurrencyMismatch);

            double totalAmount = money1.Amount + money2.Amount;

            if (double.IsPositiveInfinity(totalAmount))

                throw new System.Exception(ExceptionMessages.AmountExceeds);

            return new Money(totalAmount, money1.Currency);

        }

    }
}









