using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tavisca.WCF.ServiceContract; 
namespace Tavisca.WCF.ServiceImplementation
{
    public class Calculator : ICalculator
    {
        public string AddNumbers(string number1, string number2)
        {
            double result = double.Parse(number1) + double.Parse(number2);
            return result.ToString();
        }
        public string SubstractNumbers(string number1, string number2)
        {
            double result = double.Parse(number1) - double.Parse(number2);
            return result.ToString();
        }
        public string MultiplyNumbers(string number1, string number2)
        {
            double result = double.Parse(number1) * double.Parse(number2);
            return result.ToString();
        }
        public string DivideNumbers(string number1, string number2)
        {
            double result = double.Parse(number1) / double.Parse(number2);
            return result.ToString();
        }
    }
}
