using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EMSAutomation
{
    [TestClass]
    public class AddRemarkTest
    {
        [TestMethod]
        public void AddRemarkTestMethodSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUser")).SendKeys("isha");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("qw");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_AddRemark")).Click();

            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_DDLEmployee")).SendKeys("ritu");
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_TextAreaRemark")).SendKeys("gfhfjj");
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_ButtonAddRemark")).Click();
            var status = driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_Success")).Displayed;
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void AddRemarkTestMethodFailure()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUser")).SendKeys("isha");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("qw");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_AddRemark")).Click();

            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_DDLEmployee")).SendKeys("ritu");
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_TextAreaRemark")).SendKeys("gfhfjj");
            driver.FindElement(By.Id("FeaturedContent_HRAddRemark_ButtonAddRemark")).Click();
            var status = driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_Failure")).Displayed;
            Assert.IsTrue(status);
        }
    }
}
