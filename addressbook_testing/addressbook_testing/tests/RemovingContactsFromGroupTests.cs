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
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GettingContacts(); //Получить список контактов в группе

            app.Contacts.ContactMonitor(oldList);
            
                app.Contacts.RemoveAContact(group, 0); //Удалить контакт в группе

            List<ContactData> newList = group.GettingContacts(); ///получить новый список контактов
            app.Contacts.ContactMonitor(newList);
            oldList.RemoveAt(0); //удалить контакт из старого списка
            app.Contacts.ContactMonitor(oldList);
            Assert.AreEqual(oldList, newList); //сравнить старые и новые контакты в группе
        }
    }
}
