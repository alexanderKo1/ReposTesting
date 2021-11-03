using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin() 
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}

//Базовый класс для логирования как администратор.
//Наследовать этот класс в тестах, где нужна первоначальная авторизация
//Если используются тесты, где не нужно авторизовываться, то наследоваться от TestBase.
//Примечание: AuthTestBase наследуется от TestBase