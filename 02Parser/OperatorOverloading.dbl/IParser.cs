using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.dbl
{
    interface IParser
    {
        double ExchangeFactor(string currency, string[] currencysplitString);
    }
}
