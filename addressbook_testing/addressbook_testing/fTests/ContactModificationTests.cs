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
        public void ContactModificationTest() //Тест модификации контакта  
        {
            EntryData entryData = new EntryData("1");
            entryData.LastName = "2";

            app.Contacts.Modify(2, entryData);
        }
    }
}
