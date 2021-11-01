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
            AccountData account = new AccountData("admin", "secret");
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
            AccountData accountInv = new AccountData("11", "12");
            app.Navigator.Waiter(2);
            app.Auth.Login(accountInv);
            app.Navigator.Waiter(0);

            //Проверка
            Assert.IsFalse(app.Auth.IsLoggedIn(accountInv));
        }
    }
}
