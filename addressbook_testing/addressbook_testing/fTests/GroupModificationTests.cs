using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest() //Тест модификации группы
        {
            Group newData = new Group("A");
            newData.Header = "B";
            newData.Footer = "C";

            app.Groups.Modify(1, newData); 
        }
    }
}
