using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_testing
{
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest() //Тест удаления контакта ДЗ 7
        {
            //Предусловия
            app.Contacts.ContactCreationCondition(); //Вызов метода проверки, есть ли хотя бы один контакт. ДЗ8
            List<EntryData> oldContacts = app.Contacts.GetContactList();

            //app.Contacts.ContactMonitor(oldContacts);

            //Действие
            app.Contacts.Remove(0);
            app.Navigator.WaitFor(By.XPath("//div[@class='left']//input[@value='Delete']"), 1000, 4);

            List<EntryData> newContacts = app.Contacts.GetContactList();

            //app.Contacts.ContactMonitor(newContacts);

            oldContacts.RemoveAt(0);

            //app.Contacts.ContactMonitor(oldContacts);

            app.Contacts.ContactEquality(oldContacts, newContacts);
        }
    }
}
