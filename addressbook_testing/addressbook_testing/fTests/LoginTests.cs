using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //подготовка
            app.Auth.Logout();

            //Действие
            Account account = new Account("admin", "secret");
            app.Auth.Login(account);

            //Проверка
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //подготовка
            app.Auth.Logout();

            //Действие
            Account account = new Account("11", "12");
            app.Auth.Login(account);

            //Проверка
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
