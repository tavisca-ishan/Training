using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace OperatorOverloading.DBL
{
    public class Parser
    {
        Conversion conversion = new Conversion();
        public double Parse(string sourceCurrency, string targetCurrency)
        {
            // Read the file 

            string path = ConfigurationManager.AppSettings["FilePath"];

            if (File.Exists(path) == false) throw new Exception("File does not exists");

            String file = System.IO.File.ReadAllText(path);

            string[] initialsplitString = file.Split('{');
            if (initialsplitString[0] == null || initialsplitString[1] == null || initialsplitString[2] == null)
                throw new System.Exception("Invalid JSON Format");
            initialsplitString[0] = "";
            initialsplitString[1] = "";
            string[] currencysplitString = initialsplitString[2].Split(',');

            double getexchangeFactorOne = conversion.GetConversionRate(sourceCurrency, currencysplitString);
            double getexchangeFactorTwo = conversion.GetConversionRate(targetCurrency, currencysplitString);
            return (getexchangeFactorTwo / getexchangeFactorOne); //returning exchange rates 

        }
    }
}