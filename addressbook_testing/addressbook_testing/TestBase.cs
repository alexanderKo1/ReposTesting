using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_testing
{
    public class TestBase
    {
        protected ApplicationManagerA app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManagerA();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
