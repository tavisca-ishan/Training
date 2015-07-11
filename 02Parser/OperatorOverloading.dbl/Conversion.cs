using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Dbl
{
    public class Conversion : IParser
    {
        //performs currency conversion
        public double ExchangeFactor(string currency, string[] currencysplitString)
        {
            int i = 0;
            if (currency.Equals("USD"))
                return 1;


            for (i = 0; i < currencysplitString.Length - 1; i++)
            {

                if (currencysplitString[i].Contains(currency) == true)
                    break;
            }
            double number;

            string[] finalsplitString = currencysplitString[i].Split(':');

            double.TryParse(finalsplitString[1], out number);
            return number;


        }
    }//end of class
}//end of namespace
