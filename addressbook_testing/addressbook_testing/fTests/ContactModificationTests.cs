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
        public void ContactModificationTest()
        {
            EntryData entryData = new EntryData("Миша", "Иванов");

            app.Contacts.Modify(3, entryData);
        }
    }
}
