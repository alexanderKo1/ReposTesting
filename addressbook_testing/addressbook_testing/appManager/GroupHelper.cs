﻿using System;
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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        internal void GroupsCountCondition(int groupsCount)
        {
            if (groupsCount == 0)
            {
                manager.Groups.Create(new GroupData("Test")
                {
                    Header = "H1",
                    Footer = "H2"

                });
                System.Console.Out.WriteLine("Новая группа 'Test' создана ");
            }
        }

        //GroupRemovalTests
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }
        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                List<GroupData> groups = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                    string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                    string[] parts = allGroupNames.Split('\n');
                    int shift = groupCache.Count - parts.Length;
                    for (int i = 0; i < groupCache.Count; i++)
                    {
                        if (i < shift)
                        {
                            groupCache[i].Name = "";
                        }
                        else 
                        {
                            groupCache[i].Name = parts[i-shift].Trim();
                        }
                    }
                }
            }
            return new List <GroupData>(groupCache);
        }

        public GroupHelper Modify(int v, GroupData newData) //Метод модификации группы
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper ModifyById(GroupData toBeModified, GroupData newData) //Метод модификации группы
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(toBeModified.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage(); //Вызвать методы помощников можно с помощью менеджера
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper RemoveFrom(GroupData group)
        {
            manager.Navigator.GoToGroupsPage(); //Вызвать методы помощников можно с помощью менеджера
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        public void GroupCreationCondition()  //Метод проверки, есть ли хотя бы одна группа. ДЗ8 
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsCreated())
            {
                Create(new GroupData("groupTestA", "groupTestB"));
            }
        }

        public int GetGroupsCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public bool IsCreated() //Возвращает bool - true, если есть хотя бы одна группа. ДЗ8
        {
            return IsElementPresent(By.XPath("//div[@id='content']/form/span[1]/input"));
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }
        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
            return this;
        }
        //GroupCreationTests
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData groupD)
        {
            Type(By.Name("group_name"), groupD.Name);
            Type(By.Name("group_header"), groupD.Header);
            Type(By.Name("group_footer"), groupD.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
