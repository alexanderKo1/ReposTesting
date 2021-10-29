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
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManagerA app = ApplicationManagerA.GetInstance();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new Account("admin", "secret"));
        }

        [TearDown]
        public void StopApplicationManager()
        {
            ApplicationManagerA.GetInstance().Stop();
        }
    }
}
