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
            app.Contacts.ContactCreationConditionFromDb();

            int GroupsCount = GroupData.GetAll().Count;
            System.Console.Out.WriteLine(GroupsCount);
            app.Groups.GroupsCountCondition(GroupsCount);

            GroupData group = GroupData.GetAll()[0];
            System.Console.Out.WriteLine("Название группы: " + group.Name);

            List<ContactData> conditionCounting = group.GettingContacts();
            app.Contacts.RemovingCondition(conditionCounting, group);

            //GroupData group = GroupData.GetAll()[0]; //
            List<ContactData> oldList = group.GettingContacts();
            ContactData contact = ContactData.GetAllContacts().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            //Действия
            List<ContactData> newList = group.GettingContacts();
            oldList.Add(contact);
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
