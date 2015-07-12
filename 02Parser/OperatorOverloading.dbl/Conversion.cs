using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Dbl
{
    public class Conversion : ICurrencyConvertor
    {
        //performs currency conversion
        public double GetConversionRate(string currency, string[] currencysplitString)
        {
            int count;
            if (currency.Equals("USD"))
                return 1;
            for (count = 0; count < currencysplitString.Length - 1; count++)
            {
                if (currencysplitString[count].Contains(currency) == true)
                    break;
            }
            double number;

            string[] finalsplitString = currencysplitString[count].Split(':');

            double.TryParse(finalsplitString[1], out number);
            Console.WriteLine(number);
            return number;


        }
    }//end of class
}//end of namespace
