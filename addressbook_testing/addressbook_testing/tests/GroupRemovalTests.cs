using System;
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

            //Действие
            app.Groups.Remove(1);
        }
    }
}
