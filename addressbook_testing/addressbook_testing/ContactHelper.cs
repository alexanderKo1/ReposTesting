using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_testing
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver) : base(driver) { }
        //EntryCreationTest 135
        public void SubmitNewEntry()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        public void BackToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void NewEntry(EntryData ed)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(ed.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(ed.LastName);
        }
    }
}
