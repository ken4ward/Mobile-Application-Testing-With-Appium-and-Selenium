using System;
using OpenQA.Selenium;
using ZoneAppTesting.Functional.Reusables.SidebarReusables;
using ZoneAppTesting.Functional.Constants.Sidebar;
using OpenQA.Selenium.Appium.Android;
using ZoneAppTesting.Functional.Utils.Auth;

namespace ZoneAppTesting.Functional.Suits.SidebarSuit
{
    public class CardSuit : Base.Base
    {
        public CardSuit() { }
        public CardSuit(AndroidDriver<IWebElement> _driver) : base(_driver) { }

        public String[] OtherSidebars = { CardsConstant.RateUs, CardsConstant.AboutZone, CardsConstant.Help };
        public String[] ShareApps = { CardsConstant.Messenger, CardsConstant.WhatsApp, CardsConstant.Messages};
        public String[] ValidateElements = { CardsConstant.RateUsValidate, CardsConstant.AboutUsValidate, CardsConstant.HelpValidate };

        public void AddCards(String CardNumber, String ZoneCardNumber, String CardCVV, String ZoneCVV, String CardPIN, String ZonePIN)
        {
            _driver.FindElementByXPath(CardsConstant.AddCard).Click();
            _driver.FindElementById(CardNumber).SendKeys(ZoneCardNumber);

            new CardReusables(_driver).ExpiryDate(CardsConstant.ExpiryDatePick, CardsConstant.ExpiryMonth, CardsConstant.ExpiryYear_1, CardsConstant.ExpiryYear_2, CardsConstant.OKButton);
            _driver.FindElementById(CardCVV).Clear();
            _driver.FindElementById(CardCVV).SendKeys(ZoneCVV);

            _driver.FindElementById(CardPIN).Clear();
            _driver.FindElementById(CardPIN).SendKeys(ZonePIN);
            int ss = AndroidKeyCode.KeycodeNumpad_ENTER;
            _driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_ENTER);
            _driver.FindElementById(CardsConstant.AddCardButton).Click();
        }

        public void IterateSidebars(String SideBar)
        {
            foreach(var Elements in OtherSidebars)
            {
                _driver.PressKeyCode(AndroidKeyCode.Back);
                _driver.FindElementByXPath(SideBar).Click();
                new CardReusables(_driver).ElementClicked(Elements);
               // PageLoads();
                _driver.PressKeyCode(AndroidKeyCode.Back);
                _driver.PressKeyCode(AndroidKeyCode.Back);
                _driver.PressKeyCode(AndroidKeyCode.Back);
            }
        }

        public void PageLoads()
        {
            foreach (var i in ValidateElements)
            {
                new AuthUtils(_driver).WaitPageLoadByXPath(i);
            }
        }

        public void ShareApp(String Sidebar, String AccountSettings) {
            _driver.FindElementByXPath(Sidebar).Click();
            _driver.FindElementByXPath(AccountSettings).Click();
        }

        public void NetworkOperator(String SelectNetwork, String NetworkSelected)
        {
            _driver.FindElementByXPath(SelectNetwork).Click();
            _driver.FindElementByXPath(NetworkSelected).Click();
        }

        public void RechargeAmount(String RechargeAmount, String TypeAmount, String Amount, String TypeAmountOKButton)
        {
            _driver.FindElementByXPath(RechargeAmount).Click();
            _driver.FindElementByXPath(TypeAmount).Clear();
            _driver.FindElementByXPath(TypeAmount).SendKeys(Amount);
            _driver.FindElementByXPath(TypeAmountOKButton).Click();
            _driver.Navigate().Back();
        }

        public void ShareApplication(String Share)
        {
            _driver.FindElementByXPath(Share).Click();
            foreach(var i in ShareApps)
            {

            }
        }


    }
}
