using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    class GroupModificationTests : AuthTestBase
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

            app.Groups.Modify(0, newData); 
        }
    }
}
