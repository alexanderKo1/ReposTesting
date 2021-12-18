using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class AddNewIssueTest : TestBase
    {
        [Test]
        public void AddNewIssueMethod()
        {
            AccountData account = new AccountData()
            { Name = "administrator", Password = "root" };

            string availableId = app.Projects.GetAvailableId(); // Получить первый доступный идентификатор

            ProjectData project = new ProjectData()
            { Id = availableId };

            IssueData issue = new IssueData()
            {
                Summary = "SomeText",
                Description = "Some long Text",
                Category = "General"
            };

            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
