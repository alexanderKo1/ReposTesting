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
            GroupData group = GroupData.GetAll()[0];
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
