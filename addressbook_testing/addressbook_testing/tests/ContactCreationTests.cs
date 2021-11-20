using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_testing
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        // DATADRIVEN, BEGIN
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10))
                {
                    SecondName = GenerateRandomString(10)
                });
            }
            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>
                (File.ReadAllText(@"contacts.json"));
        }
        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0])
                {
                    SecondName = parts[1]
                });
            }
            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();

            Excel.Application app = new Excel.Application();

            app.Visible = true;

            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;

            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData(range.Cells[i, 1].Value)
                {
                    SecondName = range.Cells[i, 1].Value,
                    FirstName = range.Cells[i, 2].Value
                });;
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }
        // DATADRIVEN, END

        [Test, TestCaseSource("ContactDataFromExcelFile")]
        public void ContactCreationTest(ContactData entryData)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(entryData);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(entryData);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts); // ДЗ 9. Проверка, совпадает ли FirstName и LastName
        }
        /*
        [Test]
        public void ContactCreationTestNormal()
        {
            ContactData entryData = new ContactData("Яков");
            entryData.SecondName = "Белов";
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(entryData);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(entryData);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts); // ДЗ 9. Проверка, совпадает ли FirstName и LastName
        }
        */
    }
}
