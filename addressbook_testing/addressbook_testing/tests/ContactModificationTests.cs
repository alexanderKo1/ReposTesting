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
            ContactData entryData = new ContactData("Яков");
            entryData.LastName = "Белов";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, entryData);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].FirstName = entryData.FirstName;
            oldContacts[0].LastName = entryData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            app.Contacts.ContactMonitor(oldContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
            app.Contacts.ContactMonitor(newContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
