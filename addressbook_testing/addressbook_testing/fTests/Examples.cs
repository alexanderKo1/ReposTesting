using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace addressbook_testing.fAppmanager
{
    [TestClass]
    class Examples
    {
        [TestMethod]
        public void ExampleTestMethod()
        {
            //Пример конструкции if-else. Использование && "И", || "или"
            double example = 260;
            bool vipClient = true;

            if (example > 300 || vipClient)
            {
                example = example * 0.9;
                Console.Out.Write("Скидка 10%, общая сумма = " + example);
            }
            //else
            //{
            //    Console.Out.Write("Скидки нет, общая сумма = " + example);
            //}
        }
    }
}
