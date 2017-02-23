using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;
using System.IO;
using ZoneAppTesting.Properties;

namespace ZoneAppTesting.Functional.Reusables.Merchant
{
    public class MerchantReusables : Base.Base
    {
        public MerchantReusables() { }
        public MerchantReusables(AndroidDriver<IWebElement> _driver) : base(_driver) { }

        public void Merchant(String Merchant)
        {
            _driver.FindElementById(Merchant).Click();
        }

        public void SelectMerchant(String SelectedMerchant, String ClickedEleemnt)
        {
            IList<IWebElement> ElementSelected = _driver.FindElementsByXPath(SelectedMerchant);
            foreach (var Elements in ElementSelected)
            {
                if (Elements.Text.Equals(ClickedEleemnt))
                {
                    Elements.Click();
                    break;
                }
            }
        }

        public void SubscriptionButton(String SubscriptionButton)
        {
            _driver.FindElementByXPath(SubscriptionButton).Click(); 
        }

        public void CustomerIDItem(String CustomerIDField, String CustomerID, String SelectIcon, String SelectedElement, String RealSelected, String NextButton)
        {
            _driver.FindElementByXPath(CustomerIDField).Clear();
            _driver.FindElementByXPath(CustomerIDField).SendKeys(CustomerID);
            _driver.FindElementByXPath(SelectIcon).Click();
            IList<IWebElement> SelectElement = _driver.FindElementsByXPath(SelectedElement);
            foreach (var ElementSelected in SelectElement)
            {
                if (ElementSelected.Text.Equals(RealSelected))
                {
                    ElementSelected.Click();
                    String RemoveLastChar = ElementSelected.Text.Remove(ElementSelected.Text.Length -1);
                    File.WriteAllText(Resources.MerchantDetails, CustomerID + Environment.NewLine + RemoveLastChar);
                    break;
                }
            }
            _driver.FindElementByXPath(NextButton).Click();
        }

        public void SummaryAmount(String AmountField, String Amount, String SummaryElement, String PayButton)
        {
            _driver.FindElementByXPath(AmountField).Clear();
            _driver.FindElementByXPath(AmountField).SendKeys(Amount);
            IList<IWebElement> SummaryElements = _driver.FindElementsByXPath(SummaryElement);
            String[] AvailableElements = File.ReadAllLines(Resources.MerchantDetails);
            _driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_ENTER);
            _driver.FindElementByXPath(PayButton).Click();    
        }
    }
}
