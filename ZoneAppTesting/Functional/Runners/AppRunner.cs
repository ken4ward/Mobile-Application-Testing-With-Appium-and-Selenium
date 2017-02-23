using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using ZoneAppTesting.Functional.Utils.Auth;
using ZoneAppTesting.Functional.Constants.Auth;
using ZoneAppTesting.Functional.Constants.Sidebar;

using ZoneAppTesting.Functional.Suits.Auth;
using ZoneAppTesting.Functional.Reusables.AuthReusables;
using ZoneAppTesting.Functional.Suits.SidebarSuit;
using OpenQA.Selenium.Appium.Android;
using ZoneAppTesting.Functional.Reusables.Send;
using ZoneAppTesting.Functional.Constants.Send;
using ZoneAppTesting.Functional.Reusables.Ask;
using ZoneAppTesting.Functional.Constants.Ask;
using ZoneAppTesting.Functional.Reusables.Topup;
using ZoneAppTesting.Functional.Constants.Topup;
using ZoneAppTesting.Functional.Constants.Merchant;
using ZoneAppTesting.Functional.Reusables.Merchant;
using ZoneAppTesting.Functional.Base;

namespace AppZoneTestProjects.Functional.Runners.Login
{
    [TestClass]
    public class AppRunner
    {
        AndroidDriver<IWebElement> driver;
        private static String AppiumServerURL;
        
        
        public AppRunner()
        {
            AppiumServerURL = GetConfigurationProperty("AppiumServerURL", AuthConstant.AppiumServerURL);
            AuthUtils.WaitTime();
        }

        private static String GetConfigurationProperty(String environmentKey, String defaultValue)
        {
            String returnValue = defaultValue;
            String environmentValue = System.Environment.GetEnvironmentVariable(environmentKey);

            if (environmentValue != null)
            {
                returnValue = environmentValue;
            }
            return returnValue;
        }

        [TestMethod]
        public void HTCDesire626sDeviceRunner()
        {
            DesiredCapabilities DesiredCapability = DesiredCapabilities.Android();
            DesiredCapability.SetCapability("deviceName", AuthConstant.HTCDesire626sDevice);
            DesiredCapability.SetCapability(CapabilityType.BrowserName, "Android");
            DesiredCapability.SetCapability(CapabilityType.Version, AuthConstant.HTCDesire626sVersionNumber);
            DesiredCapability.SetCapability("platformName", "Android");
            DesiredCapability.SetCapability("appPackage", AuthConstant.ZonePackageName);
            DesiredCapability.SetCapability("appActivity", AuthConstant.ZoneAppActivity);

            DesiredCapabilityBrowser(DesiredCapability);
        }

        public void DesiredCapabilityBrowser(DesiredCapabilities DesiredCapability)
        {
            try
            {
                driver = new AndroidDriver<IWebElement>(new Uri(AuthConstant.AppiumServerURL), DesiredCapability);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));

                /*if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                {
                    new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                    new MerchantReusables(driver).Merchant(MerchantConstant.Merchant);
                    new MerchantReusables(driver).SelectMerchant(MerchantConstant.SelectedMerchant, MerchantConstant.RealMerchant);
                    new MerchantReusables(driver).SubscriptionButton(MerchantConstant.SubscriptionButton);
                    new MerchantReusables(driver).CustomerIDItem(MerchantConstant.CustomerIDField, MerchantConstant.CustomerID, MerchantConstant.PaymentItemSelect, MerchantConstant.SelectedPaymentItem, MerchantConstant.RealSelected, MerchantConstant.NextButton);
                    new MerchantReusables(driver).SummaryAmount(MerchantConstant.AmountField, MerchantConstant.Amount, MerchantConstant.SummaryElements, MerchantConstant.PayButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                }
                    new MerchantReusables(driver).Merchant(MerchantConstant.Merchant);
                    new MerchantReusables(driver).SelectMerchant(MerchantConstant.SelectedMerchant, MerchantConstant.RealMerchant);
                    new MerchantReusables(driver).SubscriptionButton(MerchantConstant.SubscriptionButton);
                    new MerchantReusables(driver).CustomerIDItem(MerchantConstant.CustomerIDField, MerchantConstant.CustomerID, MerchantConstant.PaymentItemSelect, MerchantConstant.SelectedPaymentItem, MerchantConstant.RealSelected, MerchantConstant.NextButton);
                    new MerchantReusables(driver).SummaryAmount(MerchantConstant.AmountField, MerchantConstant.Amount, MerchantConstant.SummaryElements, MerchantConstant.PayButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);

                //Topup via phone number
                if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                {
                    new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                    new TopupReusables(driver).Topup(TopupConstants.Topup);
                    new TopupReusables(driver).NavigateTopupByPhoneNumber(TopupConstants.PhoneTopupImage, TopupConstants.PhoneTopupClick);
                    new TopupReusables(driver).TopupByPhoneNumber(TopupConstants.PhoneNumberField, TopupConstants.PhoneNumber, TopupConstants.ProceedButton);
                    new TopupReusables(driver).AmountTELCO(TopupConstants.AmountField, TopupConstants.Amount, TopupConstants.TELCO, TopupConstants.SelectedTelco, TopupConstants.SelectedTELCO, TopupConstants.TopupNextButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                }
                    new TopupReusables(driver).Topup(TopupConstants.Topup);
                    new TopupReusables(driver).NavigateTopupByPhoneNumber(TopupConstants.PhoneTopupImage, TopupConstants.PhoneTopupClick);
                    new TopupReusables(driver).TopupByPhoneNumber(TopupConstants.PhoneNumberField, TopupConstants.PhoneNumber, TopupConstants.ProceedButton);
                    new TopupReusables(driver).AmountTELCO(TopupConstants.AmountField, TopupConstants.Amount, TopupConstants.TELCO, TopupConstants.SelectedTelco, TopupConstants.SelectedTELCO, TopupConstants.TopupNextButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);

                //Topup non-zone user from 
                if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                {
                    new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                    new TopupReusables(driver).Topup(TopupConstants.Topup);
                    new TopupReusables(driver).Search(TopupConstants.Search, TopupConstants.SearchField, TopupConstants.NonZoneUser);
                    new AskReusables(driver).GlobalContactList(AskConstants.GlobalContactList, TopupConstants.NonZoneUser);
                    new TopupReusables(driver).TopupPayment(TopupConstants.TopupAmount, TopupConstants.Amount, TopupConstants.TopupNextButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                }
                    new TopupReusables(driver).Topup(TopupConstants.Topup);
                    new TopupReusables(driver).Search(TopupConstants.Search, TopupConstants.SearchField, TopupConstants.NonZoneUser);
                    new AskReusables(driver).GlobalContactList(AskConstants.GlobalContactList, TopupConstants.NonZoneUser);
                    new TopupReusables(driver).TopupPayment(TopupConstants.TopupAmount, TopupConstants.Amount, TopupConstants.TopupNextButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);

                //Topup self from inside
                 if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                 {
                     new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                     new TopupReusables(driver).Topup(TopupConstants.Topup);
                     new SendReusables(driver).ValidateUserExistOnContact(SendConstant.ContactListNames);
                     new TopupReusables(driver).TopupPayment(TopupConstants.TopupAmount, TopupConstants.Amount, TopupConstants.TopupNextButton);
                     new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                 }
                 new TopupReusables(driver).Topup(TopupConstants.Topup);
                 new SendReusables(driver).ValidateUserExistOnContact(SendConstant.ContactListNames);
                 new TopupReusables(driver).TopupPayment(TopupConstants.TopupAmount, TopupConstants.Amount, TopupConstants.TopupNextButton);
                 new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);

                 //Topup zone user from inside
                 if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                 {
                     new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                     new TopupReusables(driver).Topup(TopupConstants.Topup);
                     new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                     new TopupReusables(driver).TopupPayment(TopupConstants.TopupAmount, TopupConstants.Amount, TopupConstants.TopupNextButton);
                     new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                 }
                     new TopupReusables(driver).Topup(TopupConstants.Topup);
                     new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                     new TopupReusables(driver).TopupPayment(TopupConstants.TopupAmount, TopupConstants.Amount, TopupConstants.TopupNextButton);
                     new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);


                 //Topup quick launch zone user
                  if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                  {
                      new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                      new TopupReusables(driver).TopQuickLaunch(TopupConstants.TopupQuickLaunch);
                      new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                      new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                  }
                      new TopupReusables(driver).TopQuickLaunch(TopupConstants.TopupQuickLaunch);
                      new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                      new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);

                 //ASk zone user from quick launch
                   if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                   {
                       new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                       new AskReusables(driver).AskQuickLaunch(AskConstants.AskQuickLaunch);
                       new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                       new AskReusables(driver).UniversalAsk(AskConstants.AskAmount, AskConstants.Amount, AskConstants.AskDescription, AskConstants.Description,
                           AskConstants.AskButtonGo);

                   }
                       new AskReusables(driver).AskQuickLaunch(AskConstants.AskQuickLaunch);
                       new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                       new AskReusables(driver).UniversalAsk(AskConstants.AskAmount, AskConstants.Amount, AskConstants.AskDescription, AskConstants.Description,
                           AskConstants.AskButtonGo);

                     //Ask zone user global
                   /* if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                    {
                        new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                        new AskReusables(driver).GlobalContactList(AskConstants.GlobalContactList, SendConstant.SendToUserZoneContact);
                        new AskReusables(driver).Ask(AskConstants.AskFromInside);
                        new AskReusables(driver).UniversalAsk(AskConstants.AskAmount, AskConstants.Amount, AskConstants.AskDescription, AskConstants.Description,
                            AskConstants.AskButtonGo);
                    }
                        new AskReusables(driver).GlobalContactList(AskConstants.GlobalContactList, SendConstant.SendToUserZoneContact);
                        new AskReusables(driver).Ask(AskConstants.AskFromInside);
                        new AskReusables(driver).UniversalAsk(AskConstants.AskAmount, AskConstants.Amount, AskConstants.AskDescription, AskConstants.Description,
                            AskConstants.AskButtonGo);

                    //Ask from universal 
                    /*if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                    {
                        new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                        new AskReusables(driver).Ask(AskConstants.AskButton);
                        new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                        new AskReusables(driver).UniversalAsk(AskConstants.AskAmount, AskConstants.Amount, AskConstants.AskDescription, AskConstants.Description, 
                            AskConstants.AskButtonGo);
                    }
                        new AskReusables(driver).Ask(AskConstants.AskButton);
                        new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                        new AskReusables(driver).UniversalAsk(AskConstants.AskAmount, AskConstants.Amount, AskConstants.AskDescription, AskConstants.Description,
                            AskConstants.AskButtonGo);

                    // Send to zone contact via quick launch
                    if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                    {
                        new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                        new SendReusables(driver).SendQuickLaunch(SendConstant.SendQuickLaunch);
                        new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                        new SendReusables(driver).SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                        new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                        new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);

                }
                        new SendReusables(driver).SendQuickLaunch(SendConstant.SendQuickLaunch);
                        new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                        new SendReusables(driver).SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                        new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                        new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);

                //Quick Launch send to self
                /*if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                {
                    new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                    new SendReusables(driver).SendQuickLaunch(SendConstant.SendQuickLaunch);
                    new SendReusables(driver).ValidateUserExistOnContact(SendConstant.ContactListNames);
                    new SendReusables(driver).SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                    new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                }
                    new SendReusables(driver).SendQuickLaunch(SendConstant.SendQuickLaunch);
                    new SendReusables(driver).ValidateUserExistOnContact(SendConstant.ContactListNames);
                    new SendReusables(driver).SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                    new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                    */

                //this has not been finished
                /*if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                {
                    new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                    new SendReusables(driver).Send(SendConstant.Send);
                    new SendReusables(driver).ValidateUserExistOnContact(SendConstant.ContactListNames);
                    new SendReusables(driver).InsideSend(SendConstant.InsideSend);
                }
                    new SendReusables(driver).Send(SendConstant.Send);
                    new SendReusables(driver).ValidateUserExistOnContact(SendConstant.ContactListNames);
                    new SendReusables(driver).InsideSend(SendConstant.InsideSend);

                //Send to zone contact
                /*if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                {
                    new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                    new SendReusables(driver).Send(SendConstant.Send);
                    new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                    new SendReusables(driver).SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                    new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                }
                    new SendReusables(driver).Send(SendConstant.Send);
                    new SendReusables(driver).SendToZoneContact(SendConstant.SendToZoneContact, SendConstant.SendToUserZoneContact);
                    new SendReusables(driver).SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                    new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);


                //Send to beneficiary
                /*if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                {
                    new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                    new SendReusables(driver).Send(SendConstant.Send);
                    new SendReusables(driver).BeneficiaryAccount(SendConstant.BeneficiaryButton_1, SendConstant.BeneficiaryButton_2);
                    new SendReusables(driver).AddAccountDetails(SendConstant.BeneficiarySummaryPage, SendConstant.BeneficiaryMyAccount, SendConstant.BeneficiaryBank, SendConstant.BeneficiaryMyBank, SendConstant.BeneficiaryProceedButton);
                    new SendReusables(driver).BeneficiarySummaryPage(SendConstant.BeneficiarySummaryPage, SendConstant.BeneficiaryConfirm);
                    new SendReusables(driver).SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                    new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                }
                new SendReusables(driver).Send(SendConstant.Send);
                    new SendReusables(driver).BeneficiaryAccount(SendConstant.BeneficiaryButton_1, SendConstant.BeneficiaryButton_2);
                    new SendReusables(driver).AddAccountDetails(SendConstant.BeneficiaryAccount, SendConstant.BeneficiaryMyAccount, SendConstant.BeneficiaryBank, SendConstant.BeneficiaryMyBank, SendConstant.BeneficiaryProceedButton);
                    new SendReusables(driver).BeneficiarySummaryPage(SendConstant.BeneficiarySummaryPage, SendConstant.BeneficiaryConfirm);
                    new SendReusables(driver).SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                    new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);

                //Send to Self
                if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                {
                    new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                    new SendReusables(driver).Send(SendConstant.Send);
                    new SendReusables(driver).ValidateUserExistOnContact(SendConstant.ContactListNames);
                    new SendReusables().SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                    new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                    //new SendReusables(driver).CardPINPadClick(SendConstant.CardPINPad);
                }
                    new SendReusables(driver).Send(SendConstant.Send);
                    new SendReusables(driver).ValidateUserExistOnContact(SendConstant.ContactListNames);
                    new SendReusables(driver).SendProcessFlow(SendConstant.SendAmount, SendConstant.Amount, SendConstant.SendRemarks, SendConstant.Remarks, SendConstant.SendNextButton);
                    new SendReusables(driver).SendSummaryPage(SendConstant.SummaryPageFields, SendConstant.SendSummaryButton);
                    new SendReusables(driver).CountCardNumbers(SendConstant.NumberOfCards, SendConstant.AddCardButton, SendConstant.CardPAN, SendConstant.PANLast4Digits, SendConstant.CardDigits);
                //new SendReusables(driver).CardPINPadClick(SendConstant.CardPINPad);

                 if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                {
                    new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                    new SendReusables(driver).ConfirmLoggedInUser(AuthConstant.SideBar, SendConstant.LoggedInUser);
                }
                new SendReusables(driver).ConfirmLoggedInUser(AuthConstant.SideBar, SendConstant.LoggedInUser);
                 if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                 {
                     new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                     new CardSuit(driver).ShareApp(AuthConstant.SideBar, CardsConstant.AccountSettings);
                     new CardSuit(driver).NetworkOperator(CardsConstant.SelectNetwork, CardsConstant.NetworkSelected);
                     new CardSuit(driver).RechargeAmount(CardsConstant.RechargeAmount, CardsConstant.TypeAmount, CardsConstant.RechargeAmountText, CardsConstant.TypeAmountOKButton);
                 }
                     new CardSuit(driver).ShareApp(AuthConstant.SideBar, CardsConstant.AccountSettings);
                     new CardSuit(driver).NetworkOperator(CardsConstant.NetworkOperator, CardsConstant.NetworkSelected);
                     new CardSuit(driver).RechargeAmount(CardsConstant.RechargeAmount, CardsConstant.TypeAmount, CardsConstant.RechargeAmountText, CardsConstant.TypeAmountOKButton);

                  if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                  {
                      new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                      new CardSuit(driver).IterateSidebars(AuthConstant.SideBar);
                  }
                      new CardSuit(driver).IterateSidebars(AuthConstant.SideBar);

                  if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                  {
                      new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                      driver.FindElement(By.XPath(AuthConstant.SideBar)).Click();
                      new CardReusables(driver).ReportAProblem(CardsConstant.ReportAProblem, CardsConstant.ReportSubject, CardsConstant.SubjectText,
                          CardsConstant.ReportDescribe, CardsConstant.DescribeText, CardsConstant.ReportSubmitButton);
                  }
                  driver.FindElement(By.XPath(AuthConstant.SideBar)).Click();
                  new CardReusables(driver).ReportAProblem(CardsConstant.ReportAProblem, CardsConstant.ReportSubject, CardsConstant.SubjectText,
                      CardsConstant.ReportDescribe, CardsConstant.DescribeText, CardsConstant.ReportSubmitButton);

                  //view cards test suit
                  if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                   {
                       new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                       driver.FindElement(By.XPath(AuthConstant.SideBar)).Click();
                       new CardReusables(driver).ViewCards(CardsConstant.MyCards, CardsConstant.MakeCardDefault, CardsConstant.RemoveCard, CardsConstant.RemoveCardYes);
                   }
                   else
                   {
                       driver.FindElement(By.XPath(AuthConstant.SideBar)).Click();
                       new CardReusables(driver).ViewCards(CardsConstant.MyCards, CardsConstant.MakeCardDefault, CardsConstant.RemoveCard, CardsConstant.RemoveCardYes);
                   }

                    //
                    /*if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true) {
                        new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.Password, AuthConstant.LoginButton);
                        new AuthReusables(driver).ChangePassword(AuthConstant.SideBar, AuthConstant.ChangePassword, AuthConstant.OldPassword,
                        AuthConstant.Password, AuthConstant.NewPassword, AuthConstant.NewPasswordText, AuthConstant.ConfirmNewPassword, AuthConstant.SaveNewPassowrdButton);
                    }
                    else
                    {
                        new AuthReusables(driver).ChangePassword(AuthConstant.SideBar, AuthConstant.ChangePassword, AuthConstant.OldPassword,
                        AuthConstant.Password, AuthConstant.NewPassword, AuthConstant.NewPasswordText, AuthConstant.ConfirmNewPassword, AuthConstant.SaveNewPassowrdButton);
                    }
                    new Base(driver).GetStartedButton(AuthConstant.GetStartedButton);
                    new AuthReusables(driver).Login(AuthConstant.LoginLink, AuthConstant.LoginPhoneNumber, AuthConstant.PhoneNumber, AuthConstant.LoginPassword, 
                    AuthConstant.Password, AuthConstant.LoginButton);*/

                    //Registration test suits
                    if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.InviteCodeField) == true )
                    {
                        new Base(driver).InviteCodeRun(AuthConstant.MyInviteCode, AuthConstant.VerifyInviteButton);
                        new Base(driver).GetStartedButton(AuthConstant.GetStartedButton, AuthConstant.ZoneIcon, AuthConstant.LabelPresentOnPage);
                        new AuthReusables(driver).ZoneAuthentication(AuthConstant.PhoneNumber, AuthConstant.Password, AuthConstant.VerifyPassword);
                        new AuthReusables(driver).ProfileImageGallery(AuthConstant.ProfileImage, AuthConstant.Gallery, AuthConstant.SelectImage);
                        //new AuthReusables(driver).ProfileImageCamera(AuthConstant.ProfileImage, AuthConstant.Camera);
                        new AuthSuit(driver).ProfilePageRegistration(AuthConstant.FirstName, AuthConstant.LastName, AuthConstant.Email);
                    }
                    else
                    {
                        new Base(driver).GetStartedButton(AuthConstant.GetStartedButton, AuthConstant.ZoneIcon, AuthConstant.LabelPresentOnPage);
                        new AuthReusables(driver).ZoneAuthentication(AuthConstant.PhoneNumber, AuthConstant.Password, AuthConstant.VerifyPassword);
                        new AuthReusables(driver).ProfileImageGallery(AuthConstant.ProfileImage, AuthConstant.Gallery, AuthConstant.SelectImage);
                        //new AuthReusables(driver).ProfileImageCamera(AuthConstant.ProfileImage, AuthConstant.Camera);
                        new AuthSuit(driver).ProfilePageRegistration(AuthConstant.FirstName, AuthConstant.LastName, AuthConstant.Email);
                    }
                  //Test suit to Add Card
                  /*if (new AuthSuit(driver).CheckIfElementExist(AuthConstant.LoginPasswordField) == true)
                   {
                       new AuthReusables(driver).ReLogin(AuthConstant.LoginPasswordField, AuthConstant.NewPasswordText, AuthConstant.LoginButton);
                       driver.FindElement(By.Id(AuthConstant.SideBar)).Click();
                       new CardSuit(driver).AddCards(CardsConstant.CardNumber, CardsConstant.ZoneCardNumber,
                       CardsConstant.CardCCV, CardsConstant.ZoneCVV, CardsConstant.CardPIN, CardsConstant.ZonePIN);
                   }
                   else
                   {
                       driver.FindElement(By.XPath(AuthConstant.SideBar)).Click();
                       new CardSuit(driver).AddCards(CardsConstant.CardNumber, CardsConstant.ZoneCardNumber,
                       CardsConstant.CardCCV, CardsConstant.ZoneCVV, CardsConstant.CardPIN, CardsConstant.ZonePIN);
                   }*/
            }

            catch (Exception e)
            {
                e.Message.ToString();
            }
            finally
            {
                if (driver != null)
                {
                    // driver.Close();
                }
            }
        }
    }
}
