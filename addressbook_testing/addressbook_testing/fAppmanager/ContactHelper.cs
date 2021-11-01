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
        public ContactHelper(ApplicationManagerA manager) : base(manager) { }

        public ContactHelper Modify(int v, EntryData entryData) //Метод модификации контакта
        {
            ContactCreationCondition(); //Вызов метода проверки, есть ли хотя бы один контакт. ДЗ8 
            Modify(v);
            NewEntry(entryData);
            Update();
            BackToHomePage();
            return this;
        }
        public void ContactCreationCondition() //Метод проверки, есть ли хотя бы один контакт. ДЗ8 
        {
            if (!IsCreated())
            {
                Create(new EntryData("TestA", "TestB"));
            }
        }

        public ContactHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper Modify(int v)
        {
            driver.FindElement(By.CssSelector("table#maintable tr:nth-child(" + v + ") td.center img[title='Edit']")).Click();
            return this;
        }

        public ContactHelper Remove(int ind) //Метод удаления контакта
        {
            ContactCreationCondition(); //Вызов метода проверки, есть ли хотя бы один контакт. ДЗ8 
            //SelectContactByID(ind);
            SelectContactByIndex(ind);
            RemoveCantact();
            return this;
        }
        public bool IsCreated() //Возвращает bool - true, если есть хотя бы один контакт. ДЗ8
        {
            return IsElementPresent(By.CssSelector("table#maintable tr:nth-child(2) td.center input[type='checkbox']"));
        }

        public ContactHelper SelectContactByIndex(int ind)
        {
            driver.FindElement(By.CssSelector("table#maintable tr:nth-child(" + ind + ") td.center input[type='checkbox']")).Click();
            return this;
        }

        public ContactHelper RemoveCantact()
        {
            driver.FindElement(By.XPath("//div[@class='left']//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContactByID(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']//input[@id=" + index + "]")).Click();
            return this;
        }

        //EntryCreationTest
        public ContactHelper Create(EntryData entryData)
        {
            manager.Navigator.InitNewEntryCreation();
            NewEntry(entryData);
            SubmitNewEntry();
            BackToHomePage();
            return this;
        }
        public ContactHelper SubmitNewEntry()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public ContactHelper BackToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper NewEntry(EntryData ed)
        {
            Type(By.Name("firstname"), ed.FirstName);
            Type(By.Name("lastname"), ed.LastName);
            return this;
        }
    }
}
