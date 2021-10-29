using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest() //Тест удаления контакта
        {
            app.Contacts.Remove(2); 
        }
    }
}
