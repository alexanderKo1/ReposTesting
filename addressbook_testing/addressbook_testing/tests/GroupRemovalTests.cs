using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTestDb()
        {
            //Предусловия
            app.Groups.GroupCreationCondition();  //Вызов метода проверки, есть ли хотя бы одна группа. ДЗ8
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            //Действие
            app.Groups.RemoveFrom(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
