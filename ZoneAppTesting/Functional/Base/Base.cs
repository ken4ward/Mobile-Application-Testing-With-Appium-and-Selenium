using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ZoneAppTesting.Functional.Constants.Auth;
using OpenQA.Selenium.Appium.Android;
using ZoneAppTesting.Functional.Reusables.AuthReusables;

namespace ZoneAppTesting.Functional.Base
{
    public class Base
    {
        public AndroidDriver<IWebElement> _driver;
        public Base() { }
        public Base(AndroidDriver<IWebElement> driver)
        {
            this._driver = driver;
        }

        public void GetStartedButton(String GetStartedButton, String ZoneIcon, String LabelPresentOnPage)
        {
            new AuthReusables(_driver).SlideRegistration(ZoneIcon, LabelPresentOnPage);
            _driver.FindElementByXPath(GetStartedButton).Click();
        }

        public void InviteCodeRun(String VerificationField, String VerifyInviteButton)
        {
            _driver.FindElementByXPath(AuthConstant.InviteCodeField).SendKeys(VerificationField);
            _driver.Navigate().Back();
            _driver.FindElementByXPath(VerifyInviteButton).Click();
        }

        public void SelectFromDropdown(String Field, IWebElement VariableCreated, String SearchedValue)
        {
            var gender = _driver.FindElementByXPath(Field);
            var selected = new SelectElement(VariableCreated);
            selected.SelectByText(SearchedValue);
        }

        public void CheckboxChecked(String YesElement, String NoElement)
        {
            bool ElementChecked = _driver.FindElementByXPath(YesElement).Selected;
            if (ElementChecked == false)
            {
                _driver.FindElementByXPath(YesElement).Click();
            }
            _driver.FindElementByXPath(NoElement).Click();
        }
    }
}
