using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            // Подготовка
            app.Contacts.ContactCreationConditionFromDb(); //Проверка, создан ли хотя бы один контакт

            int GroupsCount = GroupData.GetAll().Count;
            app.Groups.GroupsCountCondition(GroupsCount); // Проверка, создана ли хотя бы одна группа

            ContactData contact;

            ContactData temporaryContact = ContactData.GetAllContacts()[0]; // Выбираем контакт для добавления
            GroupData group = GroupData.GetAll()[0]; // Выбираем группу для добавления

            contact = app.Groups.AddingContactToGroupCondition(temporaryContact); //Проверка: Во всех ли группах содержится этот контакт
            contact = app.Groups.IsInGroupAlready(contact, group); //Проверка: Есть ли в этой группе такой же контакт, который добавляется

            // Действия

            List<ContactData> oldList = group.GettingContacts();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GettingContacts();

            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            // Проверка
            app.Contacts.ContactMonitor(oldList);
            app.Contacts.ContactMonitor(newList);

            Assert.AreEqual(oldList, newList);
        }
    }
}
