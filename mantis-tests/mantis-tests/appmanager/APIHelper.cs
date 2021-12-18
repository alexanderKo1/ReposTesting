using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjectsListUsingAPI(AccountData account)
        {
            List<ProjectData> allProjects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            // Получение всех объектов
            Mantis.ProjectData[] allPrjs = client.mc_projects_get_user_accessible(account.Name, account.Password);

            // Каждый объект добавляем в список проектов
            for (int i = 0; i < allPrjs.Length; i++)
            {
                string prjName = allPrjs[i].name;
                string prjId = allPrjs[i].id;

                allProjects.Add(new ProjectData(prjName, prjId));
            }
            return allProjects;
        }
    }
}
