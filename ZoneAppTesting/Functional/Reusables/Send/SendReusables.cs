using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using ZoneAppTesting.Functional.Constants.Send;
using ZoneAppTesting.Properties;
using System.Drawing;
using System.Collections.Generic;
using ZoneAppTesting.Functional.Utils.Auth;
namespace ZoneAppTesting.Functional.Reusables.Send
{
    public class SendReusables : Base.Base
    {
        Size Dimension;
        int StartPosition, EndPosition, StartFinalPosition;
        String ReturnedNames, LoggedInUserNames, SelectedCard, LastIndexOfCard;
        IWebElement SelectedElement;
        public static String[] Lines = { };
        public static String CardPAN = Resources.CardPAN;
        IList<IWebElement> AllElements;
        public static String LoggedInUserFilePath = Resources.LoggedInUserNames;
        public SendReusables() { }
        public SendReusables(AndroidDriver<IWebElement> _driver) : base(_driver) { }

        public void ConfirmLoggedInUser(String Sidebar, String LoggedInUserNames)
        {
            SwipeVertically();
            _driver.FindElementByXPath(Sidebar).Click();
            ReturnedNames = _driver.FindElementById(LoggedInUserNames).Text;
            File.WriteAllText(LoggedInUserFilePath, ReturnedNames);
        }

        public void SwipeVertically()
        {
            Dimension = _driver.Manage().Window.Size;
            StartPosition = Convert.ToInt32(Dimension.Height * 0.80);
            EndPosition = Convert.ToInt32(Dimension.Height * 0.20);
            StartFinalPosition = Dimension.Width / 2;
            //_driver.Swipe(StartFinalPosition, StartPosition, StartFinalPosition, EndPosition, 1000);
            _driver.Swipe(StartPosition, EndPosition, StartPosition, StartFinalPosition, 1000);
            
        }

        public void SwipeHorizontally()
        {
            Dimension = _driver.Manage().Window.Size;
            StartPosition = Convert.ToInt32(Dimension.Width * 0.90);
            EndPosition = Convert.ToInt32(Dimension.Width * 0.10);
            StartFinalPosition = Dimension.Height / 2;
            _driver.Swipe(StartPosition, StartFinalPosition, EndPosition, StartFinalPosition, 1000);
            // _driver.Swipe(EndPosition, StartFinalPosition, StartPosition, StartFinalPosition, 2000);
        }

        public void Send(String Send)
        {
            _driver.FindElementByXPath(Send).Click();
        }

        public void ValidateUserExistOnContact(String LoggedInUserSelector)
        {
            SelectedElement = _driver.FindElementById(LoggedInUserSelector);
            LoggedInUserNames = File.ReadAllText(LoggedInUserFilePath);
            if (SelectedElement.Text.StartsWith(LoggedInUserNames)) SelectedElement.Click();
        }

        public void SendProcessFlow(String SendAmount, String Amount, String SendRemarks, String Remarks, String SendNextButton)
        {
            _driver.FindElementByXPath(SendAmount).Clear();
            _driver.FindElementByXPath(SendAmount).SendKeys(Amount);

            _driver.FindElementByXPath(SendRemarks).Clear();
            _driver.FindElementByXPath(SendRemarks).SendKeys(Remarks);

            _driver.FindElementByXPath(SendNextButton).Click();
        }

        public void SendSummaryPage(String SummaryPageFields, String SendSummaryButton)
        {
            AllElements = _driver.FindElementsByXPath(SummaryPageFields);
            for (int i = 0; i < AllElements.Count; i++)
            {
                if (AllElements[i].Text == String.Empty)
                {
                    Console.WriteLine();
                }
            }
            _driver.FindElementByXPath(SendSummaryButton).Click(); 
        }

        public void CardSelector(String SelectedCardPAN)
        {    
            SelectedCard = _driver.FindElementByXPath(SelectedCardPAN).Text;
            if (SelectedCard != SendConstant.PANLast4Digits) SwipeHorizontally();
        }

        public void CardPINPadClick(String CardPINs)
        {
            String CardDigits = null;
            AllElements = _driver.FindElementsByXPath(CardPINs);
            for (int i = 0; i < AllElements.Count; i++) {
                CardDigits = AllElements[i].Text;
                PressCardPIN(CardDigits);
            }
        }

        public void CountCardNumbers(String Numbers, String AddCardButton, String CardPAN, String Last4Digits, String CardDigits)
        {
            String SelectedCard, LastIndexOfCard;
            SelectedCard = _driver.FindElementById(Numbers).Text;
            LastIndexOfCard = SelectedCard.Substring(SelectedCard.LastIndexOf(" ") + 1);
            int GotLastIndex = Int32.Parse(LastIndexOfCard);
            if (LastIndexOfCard == "0")
            {
                _driver.FindElementByXPath(AddCardButton).Click();
            }else if(LastIndexOfCard == "1")
            {
                SelectedCard = _driver.FindElementByXPath(CardPAN).Text;
                LastIndexOfCard = SelectedCard.Substring(Math.Max(0, SelectedCard.Length - 4));
                if (LastIndexOfCard.Equals(Last4Digits))
                { 
                    PressCardPIN(CardDigits);
                }
            }
            SelectedCard = _driver.FindElementByXPath(CardPAN).Text;
            LastIndexOfCard = SelectedCard.Substring(Math.Max(0, SelectedCard.Length - 4));
            for (int i=0; i < GotLastIndex; i++) {
                if (LastIndexOfCard.Equals(Last4Digits))
                {
                    PressCardPIN(CardDigits);
                    break;
                }
                SwipeHorizontally();
            }
        }

        public void PressCardPIN(String CardDigits)
        {
           AllElements = _driver.FindElementsByXPath(CardDigits);
            foreach(var Elements in  AllElements)
            {
                foreach (char Characters in SendConstant.PINPress)
                { 
                     if (Characters.ToString().Equals(Elements.Text))
                     {
                        Elements.Click();
                     }
                }
            }
        }

        public void BeneficiaryAccount(String BeneficiaryButton_1, String BeneficiaryButton_2)
        {
            _driver.FindElementByXPath(BeneficiaryButton_1).Click();
            _driver.FindElementByXPath(BeneficiaryButton_2).Click();
        }

        public void AddAccountDetails(String AccountNumberField, String AccountNumber, String SelectedBank, String MySelectedBank, String ProceedButton)
        {
            _driver.FindElementByXPath(AccountNumberField).Clear();
            _driver.FindElementByXPath(AccountNumberField).SendKeys(AccountNumber);
            IList<IWebElement> SelectABank = _driver.FindElementsByXPath(SelectedBank);
            foreach (var AllPresentElements in SelectABank)
            {
                if (AllPresentElements.Text.Equals(MySelectedBank)) AllPresentElements.Click();
            }
            _driver.FindElementByXPath(ProceedButton).Click();
        }

        public void BeneficiarySummaryPage(String AllSummaryElements, String ConfirmButton)
        {
            new AuthUtils(_driver).WaitPageLoadByXPath(AllSummaryElements);
            IList<IWebElement> SummaryElements = _driver.FindElementsByXPath(AllSummaryElements);
            foreach (var SumElements in SummaryElements)
            {
               String start = SumElements.Text;
               Array.Resize(ref Lines, Lines.Length + 1);
               Lines[Lines.GetUpperBound(0)] = start;
               File.WriteAllLines(Resources.SummaryPage, Lines);   
            }
                _driver.FindElementByXPath(ConfirmButton).Click();
        }

        public void SendToZoneContact(String SendToUserZoneContact, String SelectedZoneContact)
        {
            IList<IWebElement> ToZoneContact = _driver.FindElementsByXPath(SendToUserZoneContact);
            foreach (var MyZoneContact in ToZoneContact)
            {
                if (MyZoneContact.Text.Equals(SelectedZoneContact))
                {
                    MyZoneContact.Click();
                    break;
                }
            }
        }

        public void InsideSend(String InsideSend)
        {
            _driver.PressKeyCode(AndroidKeyCode.Keycode_BACK);
            _driver.FindElementByXPath(InsideSend).Click();
        }

        public void SendQuickLaunch(String SendQuickLaunch)
        {
            _driver.OpenNotifications();
            _driver.FindElementByXPath(SendQuickLaunch).Click();
        }
    }
}
