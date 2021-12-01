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
        public void TestAddingContactToGroup() //ДЗ 17
        {
            // Подготовка
            app.Contacts.ContactCreationConditionFromDb(); //Проверка, создан ли хотя бы один контакт

            int GroupsCount = GroupData.GetAll().Count;
            app.Groups.GroupsCountCondition(GroupsCount); // Проверка, создана ли хотя бы одна группа

            ContactData contact = (ContactData)app.Groups.GetAvailableContact()[0]; // контакт
            GroupData group = (GroupData)app.Groups.GetAvailableContact()[1]; // группа

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
