using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomAttributes.Testing;

namespace CustomAttributes.Model
{
    [TestClass]
    public class Calculation
    {
        [TestMethod]
        [TestCategory("UnitTest")]
        public void DoAddition()
        {
        }
        [TestMethod]
        public void FindCircleArea()
        {
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        public void FindCubeVolume()
        {
        }
    }
}
