using OpenQA.Selenium;
using SpecFlowTesting.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowTesting.Pages
{
    class LoginPage
    {
        public IWebDriver webDriver;

        public LoginPage(IWebDriver driver)
        {
            webDriver = driver;
        }
        public void NavigateToTheHomePage(String loginUrl)
        {
            //Launch TurnUp portal
            webDriver.Navigate().GoToUrl(loginUrl);

            //Maximize the browser
            webDriver.Manage().Window.FullScreen();

        }

        public String Login(String username, String password)
        {
            //Find username textbox and input username
            WebHelper.FindElement(webDriver, By.Id("UserName")).SendKeys(username);

            //Find password textbox and input password
            WebHelper.FindElement(webDriver, By.Id("Password")).SendKeys(password);

            //Find login button and click
            WebHelper.FindElement(webDriver, By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();

            webDriver.Manage().Window.FullScreen();
            return WebHelper.FindElement(webDriver, By.XPath("//*[@id='logoutForm']/ul/li/a")).Text;

        }
    }
}
