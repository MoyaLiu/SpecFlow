using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTesting.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowTesting.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver _driver;
        LoginPage loginPage = null;
        TurnupPage turnupPage = null;
        private readonly IObjectContainer _objectContainer;
        String url = "http://horse-dev.azurewebsites.net/";
        String username = "hari";
        String password = "123123";


        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario( Order = 0 )]
        public void Init()
        {
            Console.WriteLine("..................BeforeScenario");
            _driver = GetDriver();
            loginPage = new LoginPage(_driver);
            turnupPage = new TurnupPage(_driver);
        }

        [BeforeScenario(Order = 1)]
        public void NavigateToTheHomePage()
        {
            loginPage.NavigateToTheHomePage(url);
        }
        [BeforeScenario(Order = 2)]
        public void Login()
        {
            loginPage.Login(username, password);
        }
        [BeforeScenario(Order = 3)]
        public void NevigateToEmployeePage()
        {
            turnupPage.NevigateToEmployeePage();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("..................AfterScenario");
            _driver.Close();
            _driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            var browser = "Chrome";
            
            if(_driver == null)
            {
                switch(browser)
                {
                    case "Chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        var headless = "false";
                        if(headless == "true")
                        {
                            chromeOptions.AddArgument("--headless");
                        }
                        //_driver = new ChromeDriver();
                        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
                        break;
                }

                try
                {
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    _driver.Manage().Cookies.DeleteAllCookies();
                    _driver.Manage().Window.Maximize();

                    _objectContainer.RegisterInstanceAs(_driver);
                }
                catch(NullReferenceException e)
                {
                    Console.WriteLine("Fail get driver. " + e);
                }

            }
            return _driver;

        }
    }
}
