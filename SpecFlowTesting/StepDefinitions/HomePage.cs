using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowTesting.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowTesting.StepDefinitions
{
    [Binding]
    public sealed class HomePage
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        LoginPage loginPage = null;
        TurnupPage turnupPage = null;

        public HomePage(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
            turnupPage = new TurnupPage(driver);
        }

        [Given(@"I navigate to the home page")]
        public void GivenINavigateToTheHomePage(Table table)
        {
            var url = table.Rows[0][0];
            loginPage.NavigateToTheHomePage(url);
        }

        [When(@"I login to the home page")]
        public void WhenILoginToTheHomePage(Table table)
        {
            String username = table.Rows[0][0];
            String password = table.Rows[0][1];

            loginPage.Login(username, password);
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
