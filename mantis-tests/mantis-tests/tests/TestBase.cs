using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Библиотека NUnit. Рекомендуемая версия - 2.6.4;
                       //Для запуска сценариев в современных версиях браузера Firefox нужен вспомогательный исполняемый файл geckodriver.

namespace mantis_tests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
