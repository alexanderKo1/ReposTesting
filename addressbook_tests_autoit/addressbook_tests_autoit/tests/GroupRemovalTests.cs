using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoving()
        {
            app.Groups.GroupRemovingCondition();

            int indexer = 0;

            List<GroupData> checkGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.GroupRemoving(indexer);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(indexer);

            oldGroups.Sort();
            newGroups.Sort();

            System.Console.WriteLine((checkGroups.Count - 1) + " and " + app.Groups.GetGroupList().Count);
            Assert.AreEqual(checkGroups.Count - 1, app.Groups.GetGroupList().Count);

            Assert.AreEqual(oldGroups, newGroups);
            app.Groups.GroupMonitor(oldGroups);
            app.Groups.GroupMonitor(newGroups);
        }
    }
}