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
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void GoToControlPage()
        {
            driver.FindElement(By.CssSelector("div#sidebar i.fa-gears")).Click();
        }

        public void ProjectControl()
        {
            driver.FindElement(By.CssSelector("ul.nav-tabs a[href='/mantisbt-2.25.2/manage_proj_page.php']")).Click();
        }
    }
}
