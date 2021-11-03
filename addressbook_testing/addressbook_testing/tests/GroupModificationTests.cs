using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest() // Тест модификации группы ДЗ 7 
        {
            Group newData = new Group("A");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData); 
        }
    }
}
