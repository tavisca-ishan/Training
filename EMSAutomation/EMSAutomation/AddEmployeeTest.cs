using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EMSAutomation
{
    [TestClass]
    public class AddEmployeeTest
    {
        [TestMethod]
        public void AddEmployeeTestMethodSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUser")).SendKeys("isha");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("qw");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddTitle")).SendKeys("employee");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddFirstName")).SendKeys("pinchoo");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddLastName")).SendKeys("tinkoo");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddEmail")).SendKeys("p@gmail.com");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddPhone")).SendKeys("345345");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddPass")).SendKeys("ppp");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddC_Pass")).SendKeys("ppp");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_ButtonNewEmp")).Click();
            var status = driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_Success")).Displayed;
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void AddEmployeeTestMethodFailure()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:52792/Login.aspx");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxUser")).SendKeys("isha");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_TextBoxPass")).SendKeys("qw");
            driver.FindElement(By.Id("FeaturedContent_LoginUser_Button1")).Click();
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddTitle")).SendKeys("employee");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddFirstName")).SendKeys("pinchoo");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddLastName")).SendKeys("tinkoo");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddEmail")).SendKeys("p@gmail.com");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddPhone")).SendKeys("345345");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddPass")).SendKeys("ppp");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_TextBoxAddC_Pass")).SendKeys("ppp");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_ButtonNewEmp")).Click();
            var status = driver.FindElement(By.Id("FeaturedContent_HRAddEmployee_Failure")).Displayed;
            Assert.IsTrue(status);
        }
    }
}
