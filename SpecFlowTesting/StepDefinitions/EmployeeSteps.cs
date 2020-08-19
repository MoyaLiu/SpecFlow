using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTesting.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowTesting.StepDefinitions
{
    [Binding]
    public sealed class EmployeeSteps
    {
        LoginPage loginPage = null;
        TurnupPage turnupPage = null;

        public EmployeeSteps(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
            turnupPage = new TurnupPage(driver);
            Console.WriteLine("..........EmployeeSteps, driver = " + driver.GetHashCode());
            
        }

        [Given(@"I navigate to the home page")]
        public void GivenINavigateToTheHomePage()
        {
            loginPage.NavigateToTheHomePage("http://horse-dev.azurewebsites.net/");
        }

        [When(@"I login to the home page")]
        public void WhenILoginToTheHomePage()
        {
            loginPage.Login("hari", "123123");
        }


        [When(@"I navigate to the employee page")]
        public void WhenINavigateToTheEmployeePage()
        {
            turnupPage.NevigateToEmployeePage();
        }

        [Then(@"I am on the employee page")]
        public void ThenIAmOnTheEmployeePage()
        {
            Assert.AreEqual(true, turnupPage.NevigateToEmployeePage());
        }


    }
}
