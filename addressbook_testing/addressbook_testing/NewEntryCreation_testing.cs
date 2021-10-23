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
            navigationHelper.GoToHomePage();
            loginHelper.Login(new Account("admin", "secret"));
            navigationHelper.InitNewEntryCreation();
            EntryData entryData = new EntryData("Ivan", "Sergeev");
            contactHelper.NewEntry(entryData);
            contactHelper.SubmitNewEntry();
            contactHelper.BackToHomePage();

        }
    }
}
