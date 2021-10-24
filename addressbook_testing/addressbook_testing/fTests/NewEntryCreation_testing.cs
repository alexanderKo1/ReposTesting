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
            app.Navigator.InitNewEntryCreation();
            EntryData entryData = new EntryData("Ivan", "Sergeev");
            app.Contacts.NewEntry(entryData)
                .SubmitNewEntry()
                .BackToHomePage();

        }
    }
}
