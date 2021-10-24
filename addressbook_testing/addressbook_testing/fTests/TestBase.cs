using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    public class TestBase
    {
        protected ApplicationManagerA app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManagerA();

            app.Navigator.GoToHomePage();
            app.Auth.Login(new Account("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
