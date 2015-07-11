using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OperatorOverloading.Dbl
{
    public class Parser
    {
        public double Parse(string sourceCurrency, string targetCurrency)
        {
            // Read the file 
           
           string path=ConfigurationManager.AppSettings["FilePath"];
            String file = System.IO.File.ReadAllText(path);
                 
            string[] initialsplitString = file.Split('{');
            if (initialsplitString[0] == null || initialsplitString[1] == null || initialsplitString[2] == null)
                throw new System.Exception("Invalid JSON Format");
            initialsplitString[0] = "";
            initialsplitString[1] = "";
            string[] currencysplitString = initialsplitString[2].Split(',');

            double getexchangeFactorOne = new Conversion().GetConversionRate(sourceCurrency, currencysplitString);
            double getexchangeFactorTwo = new Conversion().GetConversionRate(targetCurrency, currencysplitString);

            return (getexchangeFactorTwo / getexchangeFactorOne); //returning exchange rates 

        }
    }
}
