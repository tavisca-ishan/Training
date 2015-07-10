using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.dbl;
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
        /// 
        public Money() { }
        public Money(string moneyString)
        {
            if (string.IsNullOrWhiteSpace(moneyString))
                throw new System.Exception(ExceptionMessages.NullEntered);

            if (moneyString.Length == 3)
                Currency = moneyString;
            else
            {
                string[] split = moneyString.Split(' ');
                if (split.Length != 2)
                    throw new System.Exception(ExceptionMessages.InvalidFormat);

                double amount;
                if ((double.TryParse(split[0], out amount) == false))
                    throw new System.Exception(ExceptionMessages.InvalidFormat);

                Amount = amount;
                Currency = split[1];

            }
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
        //code for currency conversion
        public double ConvertCurrency(string sourceCurrency, string targetCurrency)
        {
            sourceCurrency = sourceCurrency.ToUpper();
            targetCurrency = targetCurrency.ToUpper();
            /*if (sourceCurrency == null || targetCurrency == null)

                throw new System.Exception("Null Currency Entered!Enter Some type of Currency");*/

            if (sourceCurrency.Length != 3 || targetCurrency.Length != 3)

                throw new System.Exception("Invalid Format Of Currency!Enter Currency of length 3");
            Parser p = new Parser();
            double exchangeRates2 = p.Parse(sourceCurrency, targetCurrency);
            return exchangeRates2;
        }


    }
}







