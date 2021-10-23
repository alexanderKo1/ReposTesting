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
    public class GroupHelper
    {
        private IWebDriver driver;
        public GroupHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        //GroupRemovalTests
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
        //GroupCreationTests
        public void InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void FillGroupForm(Group GroupD)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(GroupD.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(GroupD.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(GroupD.Footer);
        }
        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
    }
}
