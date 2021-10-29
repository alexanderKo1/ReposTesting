using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class EntryCreationTest : AuthTestBase
    {
        [Test]
        public void ANewEntryCreationTest()
        {
            EntryData entryData = new EntryData("John");
            entryData.LastName = "Travolta";

            app.Contacts.Create(entryData);
        }
    }
}
