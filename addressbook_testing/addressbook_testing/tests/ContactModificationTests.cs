using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_testing
{
    class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest() //Тест модификации контакта ДЗ 7
        {
            //Предусловия
            app.Contacts.ContactCreationCondition(); //Вызов метода проверки, есть ли хотя бы один контакт. ДЗ8
            
            //Действие
            ContactData entryData = new ContactData("Владимир");
            entryData.SecondName = "Белов";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, entryData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].FirstName = entryData.FirstName;
            oldContacts[0].SecondName = entryData.SecondName;
            oldContacts.Sort();
            newContacts.Sort();

            app.Contacts.ContactMonitor(oldContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
            app.Contacts.ContactMonitor(newContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли

            Assert.AreEqual(oldContacts, newContacts);
            
            foreach (ContactData contacts in newContacts)
            {
                if (contacts.Id == oldData.Id)
                {
                    //Assert.AreEqual(entryData.FirstName, contacts.FirstName);
                    Assert.AreEqual(entryData.SecondName, contacts.SecondName);
                }
            }            
        }

        [Test]
        public void ContactModificationTestDb() // ДЗ 16 
        {
            //Предусловия
            app.Contacts.ContactCreationCondition();

            //Действие
            ContactData entryData = new ContactData("Владимир");
            entryData.SecondName = "Белов";

            List<ContactData> oldContacts = ContactData.GetAllContacts();

            ContactData oldData = oldContacts[0];

            app.Contacts.ModifyById(oldData, entryData);
            

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAllContacts();

            oldContacts[0].FirstName = entryData.FirstName;
            oldContacts[0].SecondName = entryData.SecondName;
            oldContacts.Sort();
            newContacts.Sort();

            //app.Contacts.ContactMonitor(oldContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
            //app.Contacts.ContactMonitor(newContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contacts in newContacts)
            {
                if (contacts.Id == oldData.Id)
                {
                    //Assert.AreEqual(entryData.FirstName, contacts.FirstName);
                    Assert.AreEqual(entryData.SecondName, contacts.SecondName);
                }
            }
        }
    }
}
