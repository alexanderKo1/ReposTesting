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
    public class NavigationHelper : HelperBase
    {
        protected string baseURL;
        private int attempt = 0;
        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void InitNewEntryCreation()
        {
            //if (IsElementPresent(By.LinkText("add new")))
            //{
            //    driver.FindElement(By.LinkText("add new")).Click();
            //}
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void Waiter(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }
        public void WaitFor(By by, int sec, int attempts)
        {
            do
            {
                System.Threading.Thread.Sleep(sec);
                attempt++;
            } while (driver.FindElements(by).Count == 0 && attempt < attempts);
        }
    }
}

