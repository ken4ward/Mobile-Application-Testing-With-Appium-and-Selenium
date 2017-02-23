using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;

namespace ZoneAppTesting.Functional.Utils.Auth
{
    [TestClass]
    public class AuthUtils : Base.Base
    {
        public AuthUtils() { }
        public AuthUtils(AndroidDriver<IWebElement> driver) : base(driver) { }
        public void WaitPageLoad(String InputPathLocator)
        {
            WebDriverWait tests = new WebDriverWait(_driver, TimeSpan.FromSeconds(180));
            tests.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(InputPathLocator)));
        }

        public void WaitPageLoadById(String InputPathLocator)
        {
            WebDriverWait tests = new WebDriverWait(_driver, TimeSpan.FromSeconds(180));
            tests.Until(ExpectedConditions.ElementIsVisible(By.Id(InputPathLocator)));
        }

        public void WaitPageLoadByXPath(String InputPathLocator)
        {
            WebDriverWait tests = new WebDriverWait(_driver, TimeSpan.FromSeconds(180));
            tests.Until(ExpectedConditions.ElementIsVisible(By.XPath(InputPathLocator)));
        }

        public static void WaitTime()
        {
            System.Threading.Thread.Sleep(800);
        }
    }
}
