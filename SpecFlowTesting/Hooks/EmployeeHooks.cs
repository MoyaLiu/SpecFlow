using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public sealed class EmployeeHooks
    {
        private IWebDriver _driver;

        // IOC Container for Specflow

        private readonly IObjectContainer _objectContainer;

        public EmployeeHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("..................BeforeScenario");
            _driver = GetDriver();

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
