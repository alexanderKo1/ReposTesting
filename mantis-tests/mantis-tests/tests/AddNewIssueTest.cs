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

            ProjectData project = new ProjectData()
            { Id = "58"}; //Получить первый доступный идентификатор

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
