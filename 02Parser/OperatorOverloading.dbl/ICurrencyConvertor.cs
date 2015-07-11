using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Dbl
{
    interface ICurrencyConvertor
    {
        double GetConversionRate(string currency, string[] currencysplitString);
    }
}
