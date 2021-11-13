using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_testing
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //Проверка
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllMails, fromForm.AllMails);
        }

        [Test]
        public void TestContactDetails() //ДЗ 12
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(2);

            String oneTextFromForm = app.Contacts.GetContactInformationFromEditFormInOneText(fromForm);
            System.Console.Out.Write(oneTextFromForm);

            String oneTextFromDetails = app.Contacts.GetContactInformationFromDetails(2);
            System.Console.Out.Write(oneTextFromDetails);

            //Проверка
            Assert.AreEqual(oneTextFromForm, oneTextFromDetails);
        }
    }
}
