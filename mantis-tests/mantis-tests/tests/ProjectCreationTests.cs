using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = app.Projects.ProjectCreationCondition("ТЕСТтест");

            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            app.Projects.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectsList().Count);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            app.Projects.NameChecking(oldProjects);

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
