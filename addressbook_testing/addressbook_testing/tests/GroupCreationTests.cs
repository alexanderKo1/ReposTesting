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
            GroupData group = new GroupData("121212"); //Создаем экземпляр, а далее присваиваем переменным значения, используя поля
            group.Header = "22"; //Так проще понимать, какому полю какое значение мы присвоили.
            group.Footer = "34";

            app.Groups.Create(group); //Далее можно в параметре передать созданный объект с уже необходимыми значениями
            //app.Auth.Logout();
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}
