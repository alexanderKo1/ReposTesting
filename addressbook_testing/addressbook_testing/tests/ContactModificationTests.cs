using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest() //Тест модификации контакта ДЗ 7
        {
            //Предусловия
            app.Contacts.ContactCreationCondition(); //Вызов метода проверки, есть ли хотя бы один контакт. ДЗ8
            
            //Действие
            EntryData entryData = new EntryData("Яков");
            entryData.LastName = "Белов";

            List<EntryData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(2, entryData);

            List<EntryData> newContacts = app.Contacts.GetContactList();

            //oldContacts[0].FirstName = entryData.FirstName;
            //oldContacts[0].LastName = entryData.LastName;
            oldContacts[0].FirstName = entryData.FirstName;
            oldContacts[0].LastName = entryData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            app.Contacts.ContactMonitor(oldContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
            app.Contacts.ContactMonitor(newContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли

            app.Contacts.ContactEquality(oldContacts, newContacts);
        }
    }
}
