using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new Account("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.InitNewGroupCreation();
            Group group = new Group("121212");
            group.Header = "22";
            group.Footer = "34";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
            loginHelper.Logout();
        }
    }
}
