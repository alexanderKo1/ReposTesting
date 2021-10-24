using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //Предварительно посмотреть ID контакта в addressbook на UI
            app.Contacts.Remove(13); 
        }
    }
}
