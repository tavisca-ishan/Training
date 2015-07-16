using CustomAttributes.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes.Model
{
    [TestClass]
    class Message
    {
        [TestMethod]
        public void DisplayMessage1()
        {
            Console.WriteLine("You are in Method1");
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        public void DisplayMessage2()
        {
            Console.WriteLine("You are in Method2");
        }
        [TestMethod]
        [TestCategory("UnitTest")]
        public void DisplayMessage3()
        {
            Console.WriteLine("You are in Method3");
        }
    }
}