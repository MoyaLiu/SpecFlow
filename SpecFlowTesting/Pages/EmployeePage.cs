using OpenQA.Selenium;
using SpecFlowTesting.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowTesting.Pages
{
    class EmployeePage
    {
        IWebDriver webDriver;
        public EmployeePage(IWebDriver driver)
        {
            webDriver = driver;
        }
        public Boolean NevigateToCreateNewPage()
        {
            //Find create button and click
            IWebElement createNew = WebHelper.FindElement(webDriver, By.XPath("//*[@id='container']/p/a"));
            webDriver.Manage().Window.FullScreen();
            createNew.Click();

            return WebHelper.FindElement(webDriver, By.XPath("//*[@id='container']/h2")).Text.Equals("Employee Details");
        }

        public void NevigateToTheNumbericEditPage(int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[3]/a[1]";
            Console.WriteLine("Edit Xpath - " + xpath);

            //Find the numberic button and click
            WebHelper.WaitClickable(webDriver, "XPath", xpath, 5);
            WebHelper.FindElement(webDriver, By.XPath(xpath)).Click();

            //Fill in the details
        }

        /* Delete the numberic record
         * @param The number of the record in the page list
         */
        public void DeleteTheNumbericRecord(int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[3]/a[2]";
            Console.WriteLine("Delete Xpath - " + xpath);

            //Find the numberic button and click
            WebHelper.WaitClickable(webDriver, "XPath", xpath, 5);
            WebHelper.FindElement(webDriver, By.XPath(xpath)).Click();

            //Click the alert pop-up
            IAlert alert = webDriver.SwitchTo().Alert();
            alert.Accept();
        }

        public void EditTheRecordValues(String name, String username, String contact, String password, String retypePassword, String isAdmin, String Vehicle, String Groups)
        {
            //find Name and sendkeys
            WebHelper.WaitClickable(webDriver, "XPath", "//*[@id='Name']", 5);
            WebHelper.FindElement(webDriver, By.XPath("//*[@id='Name']")).SendKeys(name);

            //find Username and sendkeys
            WebHelper.WaitClickable(webDriver, "Id", "Username", 5);
            WebHelper.FindElement(webDriver, By.Id("Username")).SendKeys(username);

            //find Password and sendkeys
            WebHelper.WaitClickable(webDriver, "Id", "Password", 5);
            WebHelper.FindElement(webDriver, By.Id("Password")).SendKeys(password);

            //find RetypePassword and sendkeys
            WebHelper.WaitClickable(webDriver, "Id", "RetypePassword", 5);
            WebHelper.FindElement(webDriver, By.Id("RetypePassword")).SendKeys(retypePassword);

            ////find others and sendkeys
            //WebHelper.WaitClickable(webDriver, "Id", "Name", 5);
            //WebHelper.FindElement(webDriver, By.Id("name")).SendKeys(name);
        }

        public void SaveTheRecord ()
        {
            WebHelper.FindElement(webDriver, By.Id("SaveButton")).Click();
        }

    }
}
