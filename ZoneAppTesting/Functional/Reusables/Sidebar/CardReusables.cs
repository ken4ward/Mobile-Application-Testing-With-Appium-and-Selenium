using System;
using OpenQA.Selenium;
using ZoneAppTesting.Functional.Constants.Sidebar;
using ZoneAppTesting.Functional.Suits.Auth;
using OpenQA.Selenium.Appium.Android;

namespace ZoneAppTesting.Functional.Reusables.SidebarReusables
{
    public class CardReusables : Base.Base
    {
        public CardReusables() { }
        public CardReusables(AndroidDriver<IWebElement> _driver) : base(_driver) { }
        public void ExpiryDate(String ExpiryDatePick, String ExpiryMonth, String ExpiryYear_1, String ExpiryYear_2, String OKButton)
        {
            _driver.FindElementByXPath(ExpiryDatePick).Click();
            _driver.FindElementByXPath(ExpiryMonth).Click();
            _driver.FindElementByXPath(ExpiryYear_1).Click();
            _driver.FindElementByXPath(ExpiryYear_2).Click();
            _driver.FindElementById(OKButton).Click();
        }

        public void ViewCards(String MyCards, String MakeCardDefault, String RemoveCard, String RemoveYes)
        {
            _driver.FindElementByXPath(MyCards).Click();
            _driver.FindElementByXPath(MakeCardDefault).Click();
           
            if(new AuthSuit(_driver).CheckIfElementExist(CardsConstant.YesDefault) == true)
            {
                new Base.Base(_driver).CheckboxChecked(CardsConstant.YesDefault, CardsConstant.NoDefault);
            }
            _driver.FindElementByXPath(RemoveCard).Click();
            new Base.Base(_driver).CheckboxChecked(CardsConstant.RemoveCardYes, CardsConstant.NoRemove);
        }

        public void ReportAProblem(String ReportAProblem, String Subject, String SubjectText, String Describe, String DescribeText, String SubmitButton)
        {
            _driver.FindElementByXPath(ReportAProblem).Click();
            _driver.FindElementByXPath(Subject).SendKeys(SubjectText);
            _driver.FindElementByXPath(Describe).SendKeys(DescribeText);
            _driver.FindElementByXPath(SubmitButton).Click();
        }

        public void ElementClicked(String ElementClicked)
        {
            _driver.FindElementByXPath(ElementClicked).Click();
        }

        public void Share(String ShareApp)
        {
            _driver.FindElementByXPath(ShareApp).Click();
        }

        public void UserSettings()
        {
            
        }
    }
}
