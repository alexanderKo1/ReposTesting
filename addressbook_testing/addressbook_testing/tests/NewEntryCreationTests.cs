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
        public void ANewEntryCreationTest()
        {
            EntryData entryData = new EntryData("Геннадий");
            entryData.LastName = "Гетроя";

            List<EntryData> oldContacts = app.Contacts.GetContactList();

            //app.Contacts.ContactMonitor(oldContacts);

            app.Contacts.Create(entryData);

            List<EntryData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(entryData);
            oldContacts.Sort();
            newContacts.Sort();

            app.Contacts.ContactEquality(oldContacts, newContacts);

            app.Contacts.ContactMonitor(oldContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
            app.Contacts.ContactMonitor(newContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
        }
    }
}
