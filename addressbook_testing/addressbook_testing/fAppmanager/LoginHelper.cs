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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManagerA manager) : base(manager) {}
        public void Login(Account account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout()
        {
            manager.Navigator.GoToHomePage();
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("form[name='logout'] a[href='#']")).Click();
                //"form[name='logout'] a[href='#']" -=- driver.FindElement(By.LinkText("Logout")).Click();
            }

        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("form[name='logout'] a[href='#']"));
            //By.Name("logout")
        }
        public bool IsLoggedIn(Account account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                    == "(" + account.Username + ")";
        }
    }
}
