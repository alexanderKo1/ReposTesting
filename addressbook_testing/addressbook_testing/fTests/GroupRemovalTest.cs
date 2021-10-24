using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTesting()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(1)
                .RemoveGroup()
                .ReturnToGroupsPage();
        }
    }
}
