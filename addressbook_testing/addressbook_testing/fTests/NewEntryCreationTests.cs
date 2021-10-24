using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class EntryCreationTest : TestBase
    {
        [Test]
        public void ANewEntryCreationTest()
        {
            EntryData entryData = new EntryData("Nicolaz", "Cage");
            app.Contacts.Create(entryData);
        }
    }
}
