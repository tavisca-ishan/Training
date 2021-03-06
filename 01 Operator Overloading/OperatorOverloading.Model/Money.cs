﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.DBL;

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
            if (string.IsNullOrWhiteSpace(moneyString))
                throw new System.Exception(ExceptionMessages.NullEntered);
            else
            {
                string[] split = moneyString.Split(' ');
                if (split.Length != 2)
                    throw new System.Exception(ExceptionMessages.InvalidFormat);

                double amount;
                if ((double.TryParse(split[0], out amount) == false))
                    throw new System.Exception(ExceptionMessages.InvalidFormat);

                Amount = amount;
                Currency = split[1].ToUpper();
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
        public Money Convert(string targetCurrency)
        {
            targetCurrency = targetCurrency.ToUpper();
            if (_currency.Length != 3 || targetCurrency.Length != 3)
                throw new System.Exception("Invalid Format Of Currency!Enter Currency of length 3");
            Parser p = new Parser();
            double exchangeRatesTwo = p.Parse(_currency, targetCurrency);
            Amount = exchangeRatesTwo * Amount;
            return new Money(Amount, targetCurrency);

        }
    }
}