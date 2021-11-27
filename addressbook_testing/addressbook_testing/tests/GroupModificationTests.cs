using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest() // Тест модификации группы ДЗ 7 
        {
            //Предусловия
            app.Groups.GroupCreationCondition();  //Вызов метода проверки, есть ли хотя бы одна группа. ДЗ8

            //Действие
            GroupData newData = new GroupData("A");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
        [Test]
        public void GroupModificationTestDb() //GroupData.GetAll
        {
            //Предусловия
            app.Groups.GroupCreationCondition();  //Вызов метода проверки, есть ли хотя бы одна группа. ДЗ8

            //Действие
            GroupData newData = new GroupData("2");
            newData.Header = "12";
            newData.Footer = "333";

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData oldData = oldGroups[0];

            app.Groups.ModifyById(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
