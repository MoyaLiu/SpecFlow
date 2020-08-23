using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTesting.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowTesting.StepDefinitions
{
    [Binding]
    public sealed class EmployeeSteps
    {

        EmployeePage employeePage = null;

        public EmployeeSteps(IWebDriver driver)
        {
            employeePage = new EmployeePage(driver);
        }

        [Given(@"I click the create button")]
        public void GivenIClickTheCreateButton()
        {
            employeePage.NevigateToCreateNewPage();
        }

        [When(@"I input the data")]
        public void WhenIInputTheData(Table table)
        {
            String name = table.Rows[0][0];
            String username = table.Rows[0][1];
            String contact = table.Rows[0][2];
            String password = table.Rows[0][3];
            String retypePassword = table.Rows[0][4];
            String isAdmin = table.Rows[0][5];
            String Vehicle = table.Rows[0][6];
            String Groups = table.Rows[0][7];

            employeePage.EditTheRecordValues(name, username, contact, password, retypePassword, isAdmin, Vehicle, Groups);
        }

        [When(@"I click the Save")]
        public void WhenIClickTheSave()
        {
            employeePage.SaveTheRecord();
        }

        [Then(@"The result should be displayed")]
        public void ThenTheResultShouldBeDisplayed()
        {
        }
    }
}
