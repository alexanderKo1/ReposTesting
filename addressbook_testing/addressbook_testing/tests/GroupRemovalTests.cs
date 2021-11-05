﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTesting()
        {
            //Предусловия
            app.Groups.GroupCreationCondition();  //Вызов метода проверки, есть ли хотя бы одна группа. ДЗ8
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //Прочитать старый список групп

            //Действие
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
