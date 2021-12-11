using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }

            Type(By.Name("username"), account.Name);
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            Type(By.CssSelector("input[id = 'password']"), account.Password);
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
        }
        public void Logout()
        {
            manager.Registration.OpenMainPage();
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span.user - info")).Click();
                driver.FindElement(By.CssSelector("ul.user-menu i.fa-sign-out")).Click();
            }

        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user - info"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Name;
        }

        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("span.user - info")).Text;
            return text;
        }
    }
}
