using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10))
                {
                    SecondName = GenerateRandomString(10)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void ContactCreationTest(ContactData entryData)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(entryData);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(entryData);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts); // ДЗ 9. Проверка, совпадает ли FirstName и LastName
        }
        [Test]
        public void ContactCreationTestNormal()
        {
            ContactData entryData = new ContactData("Яков");
            entryData.SecondName = "Белов";
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(entryData);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(entryData);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts); // ДЗ 9. Проверка, совпадает ли FirstName и LastName
        }
    }
}
