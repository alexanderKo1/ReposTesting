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

            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
                Assert.AreNotEqual(project.Name, toBeRemoved.Name);
            }
        }
    }
}
