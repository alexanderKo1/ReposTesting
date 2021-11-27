using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_testing
{
    class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest() //Тест удаления контакта ДЗ 7
        {
            //Предусловия
            app.Contacts.ContactCreationCondition(); //Вызов метода проверки, есть ли хотя бы один контакт. ДЗ8
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //Действие
            app.Contacts.Remove(0);
            app.Navigator.WaitFor(By.XPath("//div[@class='left']//input[@value='Delete']"), 1000, 4);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts); // ДЗ 9. Проверка, совпадает ли FirstName и LastName

            foreach (ContactData contacts in newContacts)
            {
                Assert.AreNotEqual(contacts.Id, toBeRemoved.Id);
            }

            app.Contacts.ContactMonitor(oldContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
            app.Contacts.ContactMonitor(newContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
        }

        [Test]
        public void ContactRemovalTestDb() 
        {
            //Предусловия
            app.Contacts.ContactCreationCondition(); //Вызов метода проверки, есть ли хотя бы один контакт. ДЗ8
            List<ContactData> oldContacts = ContactData.GetAllContacts();
            ContactData toBeRemoved = oldContacts[0];

            //Действие
            app.Contacts.RemoveFrom(toBeRemoved);
            app.Navigator.WaitFor(By.XPath("//div[@class='left']//input[@value='Delete']"), 1000, 4);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAllContacts();

            //ContactData toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts); // ДЗ 9. Проверка, совпадает ли FirstName и LastName

            foreach (ContactData contacts in newContacts)
            {
                Assert.AreNotEqual(contacts.Id, toBeRemoved.Id);
            }

            app.Contacts.ContactMonitor(oldContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
            app.Contacts.ContactMonitor(newContacts); //Вспомогательный метод, чтобы посмотреть контакты в консоли
        }
    }
}
