using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            Group group = new Group("121212");
            group.Header = "22";
            group.Footer = "34";

            app.Groups.Create(group);
            //app.Auth.Logout();
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            Group group = new Group("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}
