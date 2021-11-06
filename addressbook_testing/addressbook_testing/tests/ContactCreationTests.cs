using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class EntryCreationTest : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData entryData = new ContactData("Яков");
            entryData.LastName = "Белов";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(entryData);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(entryData);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts); // ДЗ 9. Проверка, совпадает ли FirstName и LastName

            app.Contacts.ContactMonitor(oldContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
            app.Contacts.ContactMonitor(newContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
        }
    }
}
