using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        internal void ProjectRemovalCondition()
        {
            if (GetProjectsList().Count == 0)
            {
                manager.Projects.Create(new ProjectData(RandomData()));
            }
                
        }
        internal void ProjectRemovalConditionAPI()
        {
            List<ProjectData> prjcs = manager.Projects.GetProjectsListAPI();

            if (prjcs.Count == 0)
            {
                AccountData account = new AccountData("administrator", "root");
                ProjectData projectForCreationByAPI = new ProjectData("TestProjectAPI" + RandomData());

                System.Console.Out.WriteLine("Создан проект: " + projectForCreationByAPI.Name);

                manager.API.CreateNewProjectUsingAPI(account, projectForCreationByAPI);
                projectCache = null;
            }

        }

        internal string GetAvailableId()
        {
            List<ProjectData> projects = GetProjectsListAPI();

            if (projects.Count == 0)
            {
                AccountData account = new AccountData("administrator", "root");
                ProjectData projectForCreationByAPI = new ProjectData("TestProjectAPI" + RandomData());

                System.Console.Out.WriteLine("Создан проект: " + projectForCreationByAPI.Name);

                manager.API.CreateNewProjectUsingAPI(account, projectForCreationByAPI);
                projectCache = null;

                return GetProjectsListAPI()[0].Id;
            }
            return projects[0].Id;
        }

        public ProjectHelper Remove(int indexer)
        {
            manager.MngmMenuHelper.GoToControlPage();
            manager.MngmMenuHelper.ProjectControl();

            SelectProjectForRemoving(indexer);
            RemoveProject();
            SubmitRemoving();

            manager.MngmMenuHelper.GoToControlPage();
            return this;
        }

        public void NameChecking(List<ProjectData> oldProjects)
        {
            List<ProjectData> projectsList = manager.Projects.GetProjectsList();

            oldProjects.Sort();
            projectsList.Sort();

            for (int i = 0; i < projectsList.Count; i++)
            {
                Assert.AreEqual(oldProjects[i].Name, projectsList[i].Name);
                System.Console.Out.WriteLine(oldProjects[i].Name + " and " + projectsList[i].Name);
            }
        }

        private void SubmitRemoving()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            projectCache = null;
        }

        private void RemoveProject()
        {
            driver.FindElement(By.CssSelector("form[id='project-delete-form'] input.btn")).Click();
        }

        private void SelectProjectForRemoving(int indexer)
        {
            By.CssSelector("div.widget-box:nth-child(2) tbody tr:nth-child( " + indexer + " )");
                driver.FindElement(By.CssSelector("td:nth-child(1) a")).Click();
        }

        //
        internal ProjectData ProjectCreationCondition(string name)
        {
            List<ProjectData> projects = GetProjectsList();

            foreach (ProjectData projectForUse in projects)
            {
                if (projectForUse.Name == name)
                {
                    return new ProjectData(RandomData());
                }
            }
            return new ProjectData(name);
        }

        public string RandomData()
        {
            Random random = new Random();
            int value = random.Next(1, 100);
            return "Test data " + Convert.ToString(value);
        }

        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectsList()
        {
            manager.Projects.WaitFor(By.CssSelector("div.widget-toolbox form[method='post'] button[type='submit']"), 1000, 4);
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();

                manager.MngmMenuHelper.GoToControlPage();
                manager.MngmMenuHelper.ProjectControl();

                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("div.widget-box:nth-child(2) tbody tr"));
                foreach (IWebElement element in elements)
                {
                    projectCache.Add(new ProjectData(element.FindElement(By.XPath("td[1]")).Text)
                    {
                        Id = (element.FindElement(By.TagName("a")).GetAttribute("href")).Replace("http://localhost/mantisbt-2.25.2/manage_proj_edit_page.php?project_id=", "")
                    });
                }
            }
            return new List<ProjectData>(projectCache);
        }
        public List<ProjectData> GetProjectsListAPI()
        {
            if (projectCache == null)
            {
                AccountData account = new AccountData("administrator", "root");
                List<ProjectData> prjs = manager.API.GetProjectsListUsingAPI(account);

                projectCache = new List<ProjectData>();

                foreach (ProjectData project in prjs)
                {
                    projectCache.Add(new ProjectData(project.Name)
                    {
                        Id = project.Id
                    }); ;
                }
            }
            return new List<ProjectData>(projectCache);
        }
        public ProjectHelper Create(ProjectData project)
        {
            manager.MngmMenuHelper.GoToControlPage();
            manager.MngmMenuHelper.ProjectControl();

            InitNewProjectCreation();
            FillTheFields(project);
            Submit();
            Continue();
            manager.MngmMenuHelper.GoToControlPage();
            return this;
        }

        public void Continue()
        {
            driver.FindElement(By.CssSelector("div.btn-group a.btn")).Click();
            projectCache = null;
            //manager.Projects.WaitFor(By.CssSelector("div.widget-toolbox form[method='post'] button[type='submit']"), 1000, 4);
        }

        private int attempt = 0;
        public void WaitFor(By by, int sec, int attempts)
        {
            do
            {
                System.Threading.Thread.Sleep(sec);
                attempt++;
            } while (driver.FindElements(by).Count == 0 && attempt < attempts);
        }

        public void Submit()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        public void FillTheFields(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
        }

        public void InitNewProjectCreation()
        {
            driver.FindElement(By.CssSelector("div.widget-toolbox form[method='post'] button[type='submit']")).Click();
        }

        //
        public void ProjectMonitor(List<ProjectData> projects)
        {
            int nn = 0;
            for (int i = 0; i < projects.Count; i++)
            {
                System.Console.Out.Write("#: " + i + " | " + "Id: "+ projects[i].Id +" | " + "Название проекта: " + projects[i].Name);
            }
            System.Console.Out.Write("FINISHED" + "\n");
        }
    }
}
