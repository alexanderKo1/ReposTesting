using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest() //Тест удаления контакта ДЗ 7
        {
            //Предусловия
            app.Contacts.ContactCreationCondition(); //Вызов метода проверки, есть ли хотя бы один контакт. ДЗ8 

            //Действие
            app.Contacts.Remove(2); 
        }
    }
}
