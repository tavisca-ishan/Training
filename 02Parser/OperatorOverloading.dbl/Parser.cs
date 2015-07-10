using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.dbl
{
    public class Parser
    {
        public double Parse(string sourceCurrency, string targetCurrency)
        {
            // Read the file and display it line by line.
            string fileData = "";
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"D:\Training\02 Parser\OperatorOverloading.dbl\ParseFile.txt");
            while ((line = file.ReadLine()) != null)
            {
                fileData += line;

            }
            file.Close();
            string[] initialsplitString = fileData.Split('{');
            initialsplitString[0] = "";
            initialsplitString[1] = "";
            string[] currencysplitString = initialsplitString[2].Split(',');

            double getexchangeFactor1 = new Conversion().ExchangeFactor(sourceCurrency, currencysplitString);
            double getexchangeFactor2 = new Conversion().ExchangeFactor(targetCurrency, currencysplitString);

            return (getexchangeFactor2 / getexchangeFactor1); //returning exchange rates 

        }
    }
}
