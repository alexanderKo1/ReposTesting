using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium; //Необходимая библиотека Selenium. Установить в менеджере пакетов (ПКМ на References -> Manage NuGet Packages)
using OpenQA.Selenium.Firefox; //Нужно установить Selenium.WebDriver и Selenium.Support
using OpenQA.Selenium.Support.UI; //Также необходим NUnit Test adapter (2.6.4), что бы были доступны тесты фреймворка NUnit

namespace addressbook_testing
{
    public class ApplicationManager
    {
        // protected - наследники могут доступиться до поля. Похож на private
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost"; 

            //Инициализация Помощников
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        { 
            if (! app.IsValueCreated) //Если объект не создан, то создать. Если создан - то исп. существующий. (Singleton) 
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        //Свойства, чтобы доступиться до помощников
        public IWebDriver Driver 
        {
            get 
            {
                return driver;
            }
        }
        public LoginHelper Auth
        {
            get 
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }
    }
}


/*
NOTES

Менеджер:
field -> Initialisaion in constructor of the manager -> Property
[I] В тестах вызываем через app.
    В помощниках вызываем через manager.


*/