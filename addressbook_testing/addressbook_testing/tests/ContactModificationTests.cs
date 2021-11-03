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
            EntryData entryData = new EntryData("24");
            entryData.LastName = "32";

            app.Contacts.Modify(2, entryData);
        }
    }
}
