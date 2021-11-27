using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareCantactsUI_DB()
        {
            if (CONTACTS_PERFOM_LONG_UI_CHECKS)
            {
                List<ContactData> fromUI = app.Contacts.GetContactList();
                List<ContactData> fromDB = ContactData.GetAllContacts();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
