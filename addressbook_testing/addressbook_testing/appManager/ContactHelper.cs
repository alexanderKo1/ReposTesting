using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };
        }

        internal ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        public ContactHelper Modify(int v, ContactData entryData) //Метод модификации контакта
        {
            Modify(v);
            NewEntry(entryData);
            Update();
            BackToHomePage();
            return this;
        }
        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                //List<ContactData> contacts = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='maintable']//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElement(By.XPath("td[3]")).Text, element.FindElement(By.XPath("td[2]")).Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactsCount()
        {
            return driver.FindElements(By.XPath("//table[@id='maintable']//tr[@name='entry']")).Count;
        }

        public void ContactMonitor(List<ContactData> Contacts)
        {
            int nn = 0;
            foreach (ContactData element in Contacts)
            {
                System.Console.Out.Write((++nn) + " | " + element.Id + " | " + element.ToString());
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
                Assert.AreEqual(oldContacts[i].SecondName, newContacts[i].SecondName);
            }
        }
        public ContactHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper Modify(int v)
        {
            driver.FindElement(By.CssSelector("table#maintable tr:nth-child(" + (v + 2) + ") td.center img[title='Edit']")).Click();
            return this;
        }
        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactHelper Remove(int ind) //Метод удаления контакта
        { 
            //SelectContactByID(ind);
            SelectContactByIndex(ind);
            RemoveCantact();
            contactCache = null;
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
            contactCache = null;
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
            Type(By.Name("lastname"), ed.SecondName);
            return this;
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
