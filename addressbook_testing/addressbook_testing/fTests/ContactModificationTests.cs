using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest() //Тест модификации контакта 
        {
            EntryData entryData = new EntryData("Фёдор2", "Владимирв2");

            app.Contacts.Modify(13, entryData);
        }
    }
}
