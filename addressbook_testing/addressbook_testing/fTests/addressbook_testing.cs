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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new Account("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            Group group = new Group("121212");
            group.Header = "22";
            group.Footer = "34";
            app.Groups.InitNewGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            //app.Auth.Logout();
        }
    }
}
