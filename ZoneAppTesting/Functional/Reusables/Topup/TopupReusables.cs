using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using System.Collections.Generic;
using ZoneAppTesting.Functional.Utils.Auth;

namespace ZoneAppTesting.Functional.Reusables.Topup
{
    public class TopupReusables : Base.Base
    {
        public TopupReusables() { }
        public TopupReusables(AndroidDriver<IWebElement> _driver) : base(_driver) { }
        
        public void TopQuickLaunch(String TopQuickLaunch)
        {
            _driver.OpenNotifications();
            _driver.FindElementByXPath(TopQuickLaunch).Click();
        }

        public void Topup(String Topup)
        {
            _driver.FindElementByXPath(Topup).Click();
        }

        public void TopupPayment(String TopupAmount, String Amount, String TopupNextButton)
        {
            _driver.FindElementByXPath(TopupAmount).Clear();
            _driver.FindElementByXPath(TopupAmount).SendKeys(Amount);
            _driver.FindElementByXPath(TopupNextButton).Click();
        }

        public void Search(String Search, String SearchField, String NonZoneUser)
        {
            _driver.FindElementByXPath(Search).Click();
            _driver.FindElementById(SearchField).Clear();
            _driver.FindElementById(SearchField).SendKeys(NonZoneUser);
        }

        public void NavigateTopupByPhoneNumber(String PhoneTopupImage, String PhoneTopupClick)
        {
            _driver.FindElementByXPath(PhoneTopupImage).Click();
            _driver.FindElementByXPath(PhoneTopupClick).Click();
            
        }

        public void TopupByPhoneNumber(String PhoneNumberField, String PhoneNumber, String ProceedButton)
        {
            _driver.FindElementByXPath(PhoneNumberField).Clear();
            _driver.FindElementByXPath(PhoneNumberField).SendKeys(PhoneNumber);
            _driver.FindElementByXPath(ProceedButton).Click();
        }

        public void AmountTELCO(String AmountField, String Amount, String TELCO, String SelectedTelco, String SelectedTELCO, String ButtonNext)
        {
            new AuthUtils(_driver).WaitPageLoadByXPath(TELCO);
            _driver.FindElementByXPath(AmountField).Clear();
            _driver.FindElementByXPath(AmountField).SendKeys(Amount);
            _driver.FindElementByXPath(TELCO).Click();
            IList<IWebElement> TELCOElements = _driver.FindElementsByXPath(SelectedTelco);
            foreach (var Telcos in TELCOElements)
            {
                if (Telcos.Text.Equals(SelectedTELCO))
                {
                    Telcos.Click();
                    break;
                }
            }
            _driver.FindElementByXPath(ButtonNext).Click();
        }
    }
}
