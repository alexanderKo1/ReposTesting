using System;
using System.Collections.Generic;
using System.IO;
using addressbook_testing;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]); //lines
            string fileName = args[1]; //.csv, .json, .xml, .xlsx
            string format = args[2]; //csv, json, xml, excel
            string type = args[3]; //groups, contacts 

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

            if (type == "groups")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, fileName);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(fileName);

                    if (format == "csv")
                    {
                        writeGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Неопознанный формат " + format);
                    }
                    writer.Close();
                }
            }
            else if (type == "contacts") //ДЗ 14: Сделал так, чтобы аргументом принимался тип groups или contacts 
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        SecondName = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "excel")
                {
                    writeContactsToExcelFile(contacts, fileName);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(fileName);

                    if (format == "csv")
                    {
                        writeContactsToCsvFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        writeContactsToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        writeContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Неопознанный формат " + format);
                    }
                    writer.Close();
                }
            }
            else
            {
                System.Console.Out.Write("Неопознанный тип данных " + type + ", введите contacts или groups");
            }
        }

        // CONTACTS
        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}",
                    contact.FirstName, contact.SecondName));
            }
        }

        static void writeContactsToExcelFile(List<ContactData> contacts, string fileName)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.FirstName;
                sheet.Cells[row, 2] = contact.SecondName;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        // GROUPS
        static void writeGroupsToExcelFile(List<GroupData> groups, string fileName)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
            //sheet.Cells[1, 1] = "test";
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        { 
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
