using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    public class RemovingContactsFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup() //ДЗ 17
        {
            // Подготовка
            //app.Contacts.ContactCreationConditionFromDb();

            int GroupsCount = GroupData.GetAll().Count;
            System.Console.Out.WriteLine(GroupsCount);
            app.Groups.GroupsCountCondition(GroupsCount);

            // Получение контакта и группы
            ContactData contact = (ContactData)app.Groups.GetAvailableContactForRemoving()[0]; // контакт
            GroupData group = (GroupData)app.Groups.GetAvailableContactForRemoving()[1]; // группа

            System.Console.Out.WriteLine("Название группы: " + group.Name);

            //Действие
            List<ContactData> oldList = group.GettingContacts(); //Получить список контактов в группе

            app.Contacts.ContactMonitor(oldList);

            app.Contacts.RemoveAContact(group, contact); //Удалить контакт в группе

            List<ContactData> newList = group.GettingContacts(); ///получить новый список контактов
            app.Contacts.ContactMonitor(newList);

            oldList.RemoveAt(0); //удалить контакт из старого списка
            app.Contacts.ContactMonitor(oldList);
            
            oldList.Sort();
            newList.Sort();

            //Проверка
            Assert.AreEqual(oldList, newList); //сравнить старые и новые контакты в группе 
        }
    }
}
