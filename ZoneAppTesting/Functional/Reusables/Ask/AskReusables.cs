using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using ZoneAppTesting.Functional.Utils.Auth;
using System.Drawing;
using System.Collections.Generic;

namespace ZoneAppTesting.Functional.Reusables.Ask
{
    [TestClass]
    public class AskReusables : Base.Base
    {
       public AskReusables() { }
       public AskReusables(AndroidDriver<IWebElement> _driver) : base(_driver) { }

        public void Ask(String AskButton)
        {
            _driver.FindElementByXPath(AskButton).Click();
        }
        public void UniversalAsk(String AmountField, String Amount,  String AskDescription, String Description, String AskButtonGo)
        {
            _driver.FindElementByXPath(AmountField).Clear();
            _driver.FindElementByXPath(AmountField).SendKeys(Amount);

            _driver.FindElementByXPath(AskDescription).Clear();
            _driver.FindElementByXPath(AskDescription).SendKeys(Description);

            /*_driver.FindElementByXPath(AskAddImage).Click();
            _driver.FindElementByXPath(SelectImageGallery).Click();
            new AuthUtils(_driver).WaitPageLoadByXPath(ImageViewGallery);
            _driver.FindElementByXPath(ImageViewGallery).Click();*/

            _driver.FindElementByXPath(AskButtonGo).Click();
        }

        public void AskFromInside(String AskFromInside)
        {
            _driver.FindElementByXPath(AskFromInside).Click();
        }

        public void GlobalContactList(String GlobalContactLists, String UserToclick)
        {
            IList<IWebElement> ListContacts = _driver.FindElementsByXPath(GlobalContactLists);
            foreach (var ListElements in ListContacts)
            {
                if (ListElements.Text.Equals(UserToclick))
                {
                    ListElements.Click();
                    break;
                }
            }
        }

        public void AskQuickLaunch(String AskQuickLaunch)
        {
            _driver.OpenNotifications();
            _driver.FindElementByXPath(AskQuickLaunch).Click();
        }
    }
}
