using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Библиотека NUnit. Рекомендуемая версия - 2.6.4;
                       //Для запуска сценариев в современных версиях браузера Firefox нужен вспомогательный исполняемый файл geckodriver.

namespace addressbook_testing
{
    public class TestBase
    {
        public static bool PERFOM_LONG_UI_CHECKS = true;
        public static bool CONTACTS_PERFOM_LONG_UI_CHECKS = false;
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
