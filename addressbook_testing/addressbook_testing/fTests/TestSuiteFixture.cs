using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        public static ApplicationManagerA app;

        [SetUp]
        public void InitApplicationManager()
        {
            app = new ApplicationManagerA();

            app.Navigator.GoToHomePage();
            app.Auth.Login(new Account("admin", "secret"));
        }

        [TearDown]
        public void DtopApplicationManager()
        {
            app.Stop();
        }
    }
}
