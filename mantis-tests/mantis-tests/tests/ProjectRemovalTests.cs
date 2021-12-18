using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            //Предусловия
            app.Projects.ProjectRemovalCondition();
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            ProjectData toBeRemoved = oldProjects[0];

            //Действие
            app.Projects.Remove(0);
           
            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectsList().Count);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();

            oldProjects.RemoveAt(0);

            app.Projects.NameChecking(oldProjects);

            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }
        }
        [Test]
        public void ProjectRemovalTestAPI()
        {
            //Предусловия
            app.Projects.ProjectRemovalConditionAPI();

            System.Threading.Thread.Sleep(2000);

            List<ProjectData> oldProjects = app.Projects.GetProjectsListAPI();
            app.Projects.ProjectMonitor(oldProjects);

            ProjectData toBeRemoved = oldProjects[0];

            //Действие
            app.Projects.Remove(0);

            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectsListAPI().Count);

            List<ProjectData> newProjects = app.Projects.GetProjectsListAPI();

            oldProjects.RemoveAt(0);

            app.Projects.NameChecking(oldProjects);

            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }
        }
    }
}
