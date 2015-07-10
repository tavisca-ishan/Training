using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.dbl
{
    class Parse : IParser
    {
        Dictionary<string, double> exchangeRates = new Dictionary<string, double>();
        public string Source
        {
            get;
            set;
        }

        public Dictionary<string, double> ParseFile(string jsonBuilder)
        {
            if (jsonBuilder == null)
            {
                throw new NullReferenceException("Null Input String");
            }
            string data = jsonBuilder;
            string[] splitData = data.Split('{');
            string tempData = splitData[1];
            string[] tempSplit1 = tempData.Split(',');
            tempSplit1 = tempSplit1[tempSplit1.Length - 2].Split(':'); 
            Source = tempSplit1[1];

            data = splitData[2];
            data = data.Replace('}', ' ');
            data = data.Trim();
            splitData = data.Split(',');
            for (int i = 0; i < splitData.Length; i++)
            {
                splitData[i] = splitData[i].Replace("USD", "");
                tempSplit1 = splitData[i].Split(':');
                data = tempSplit1[0];
                double value = 0.0;
                if (double.TryParse(tempSplit1[1], out value) == false)
                    throw new Exception("Invalid Number.");
                data = data.Remove(data.Length - 1, 1);
                data = data.Remove(0, 1);

                exchangeRates.Add(data, value);
                Console.WriteLine(data);
            }
            return exchangeRates;

        }
    }
}
