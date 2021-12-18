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

        [Test]
        public void ProjectCreationTestAPI()
        {
            ProjectData project = app.Projects.ProjectCreationCondition("324");

            List<ProjectData> oldProjects = app.Projects.GetProjectsListAPI();

            app.Projects.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectsListAPI().Count);

            List<ProjectData> newProjects = app.Projects.GetProjectsListAPI();

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            app.Projects.NameChecking(oldProjects);

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
