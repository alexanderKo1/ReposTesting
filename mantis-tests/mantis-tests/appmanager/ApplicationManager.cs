using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected ManagementMenuHelper mngmMenuHelper;
        protected ProjectHelper projects;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.2";

            loginHelper = new LoginHelper(this);
            mngmMenuHelper = new ManagementMenuHelper(this);
            Registration = new RegistrationHelper(this);
            projects = new ProjectHelper(this);

            Ftp = new FTPHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Admin = new AdminHelper(this, baseURL);

            API = new APIHelper(this);
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
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
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
        public ManagementMenuHelper MngmMenuHelper
        {
            get
            {
                return mngmMenuHelper;
            }
        }
        public ProjectHelper Projects
        {
            get
            {
                return projects;
            }
        }
        public RegistrationHelper Registration { get; set; }
        public FTPHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }
    }
}