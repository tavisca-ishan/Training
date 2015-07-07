using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operator_Overloading.Model;

namespace Operator_Overloading.Host
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Money Money1 = new Money();   // Declare Money1 of type Money
                Money Money2 = new Money();   // Declare Money2 of type Money
                Money Money3 = new Money();

                Console.WriteLine("Enter currency and amount for first user");
                Money1.getCurrency(); //recieve currency for first user
                Money1.getAmount();   //recieve amount for first user
                Console.WriteLine("Enter currency and amount for second user");
                Money2.getCurrency(); //recieve currency for second user
                Money2.getAmount(); //recieve amount for seoond user


                Money3 = Money1 + Money2;

                Console.WriteLine("Total Amount : {0} ", Money3.amount); 
            }
            catch (ArgumentException e1)
            {
                Console.WriteLine(e1);
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
            Console.ReadKey();
           }//end of main
    }
}