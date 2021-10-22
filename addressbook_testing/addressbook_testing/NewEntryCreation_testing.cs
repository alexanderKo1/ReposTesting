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
            GoToHomePage();
            Login(new Account("admin", "secret"));
            InitNewEntryCreation();
            EntryData entryData = new EntryData("Ivan", "Sergeev");
            NewEntry(entryData);
            SubmitNewEntry();
            BackToHomePage();

        }
    }
}
