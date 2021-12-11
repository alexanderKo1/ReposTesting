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

            //Действие
            app.Projects.Remove(0);
           
            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectsList().Count);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();

            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
