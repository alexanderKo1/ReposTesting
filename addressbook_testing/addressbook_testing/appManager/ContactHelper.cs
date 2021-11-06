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
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactHelper Modify(int v, ContactData entryData) //Метод модификации контакта
        {
            Modify(v);
            NewEntry(entryData);
            Update();
            BackToHomePage();
            return this;
        }
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='maintable']//tr[@name='entry']"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.FindElement(By.XPath("td[3]")).Text, element.FindElement(By.XPath("td[2]")).Text));
            }

            return contacts;
        }

        public int GetContactsCount()
        {
            return driver.FindElements(By.XPath("//table[@id='maintable']//tr[@name='entry']")).Count;
        }

        public void ContactMonitor(List<ContactData> Contacts)
        {
            int id = 0;
            foreach (ContactData element in Contacts)
            {
                System.Console.Out.Write((++id) + " | " + element.ToString());
            }
            System.Console.Out.Write("FINISHED" + "\n");
        }
        public void ContactCreationCondition() //Метод проверки, есть ли хотя бы один контакт. ДЗ8 
        {
            if (!IsCreated())
            {
                Create(new ContactData("TestA", "TestB"));
            }
        }
        public void ContactEquality(List<ContactData> oldContacts, List<ContactData> newContacts) //Проверка совпадений FirstName и LastName. ДЗ 9
        {
            for (int i = 0; i < oldContacts.Count; i++)
            {
                Assert.AreEqual(oldContacts[i].FirstName, newContacts[i].FirstName);
                Assert.AreEqual(oldContacts[i].LastName, newContacts[i].LastName);
            }
        }
        public ContactHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper Modify(int v)
        {
            driver.FindElement(By.CssSelector("table#maintable tr:nth-child(" + (v + 2) + ") td.center img[title='Edit']")).Click();
            return this;
        }

        public ContactHelper Remove(int ind) //Метод удаления контакта
        { 
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
            driver.FindElement(By.CssSelector("table#maintable tr:nth-child(" + (ind + 2) + ") td.center input[type='checkbox']")).Click();
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
        public ContactHelper Create(ContactData entryData)
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
        public ContactHelper NewEntry(ContactData ed)
        {
            Type(By.Name("firstname"), ed.FirstName);
            Type(By.Name("lastname"), ed.LastName);
            return this;
        }
    }
}
