using System;
using OpenQA.Selenium;
using ZoneAppTesting.Functional.Constants.Auth;
using OpenQA.Selenium.Appium.Android;
using ZoneAppTesting.Functional.Utils.Auth;
using System.Collections.Generic;
using ZoneAppTesting.Functional.Reusables.Send;
using System.IO;
using ZoneAppTesting.Properties;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;

namespace ZoneAppTesting.Functional.Reusables.AuthReusables
{
    public class AuthReusables : Base.Base
    {
        Size Dimension;
        public AuthReusables() { }
        public AuthReusables(AndroidDriver<IWebElement> driver) : base(driver) { }
        public static String PhoneNumberField, PasswordField, VerifyPasswordField;
        public static String[] LabelsAvailable = { AuthConstant.SlideAsk, AuthConstant.SlidePay, AuthConstant.SlideMerchant, AuthConstant.SlideSend };
        public void ZoneAuthentication(String PhoneNumberField, String PasswordField, String VerifyPasswordField)
        {
            AuthReusables.PhoneNumberField = PhoneNumberField;
            AuthReusables.PasswordField = PasswordField;
            AuthReusables.VerifyPasswordField = VerifyPasswordField;

            _driver.FindElementByXPath(AuthConstant.PhoneNumberField).Clear();
            //_driver.FindElement(By.XPath(AuthConstant.PhoneNumberField)).SendKeys(Keys.Control + "a");
            _driver.FindElementByXPath(AuthConstant.PhoneNumberField).SendKeys(AuthReusables.PhoneNumberField);

            _driver.FindElementByXPath(AuthConstant.PasswordField).Clear();
            // _driver.FindElement(By.XPath(AuthConstant.PasswordField)).SendKeys(Keys.Control + "a");
            _driver.FindElementByXPath(AuthConstant.PasswordField).SendKeys(AuthReusables.PasswordField);

            _driver.FindElementByXPath(AuthConstant.VerifyPasswordField).Clear();
            // _driver.FindElement(By.XPath(AuthConstant.VerifyPasswordField)).SendKeys(Keys.Control + "a");
            _driver.FindElementByXPath(AuthConstant.VerifyPasswordField).SendKeys(AuthReusables.VerifyPasswordField);

            _driver.FindElementByXPath(AuthConstant.ProceedButton).Click();
        }

        public void Login(String LoginLink, String LoginPhoneNumber, String PhoneNumber, String LoginPassword,  String Password, String LoginButton)
        {
            _driver.Navigate().Back();
            _driver.FindElementById(LoginLink).Click();
            _driver.FindElementByXPath(LoginPhoneNumber).Clear();
            _driver.FindElementByXPath(LoginPhoneNumber).SendKeys(PhoneNumber);
            _driver.FindElementById(LoginPassword).SendKeys(Password);
            _driver.FindElementById(LoginButton).Click();
        }

        public void ChangePassword(String SideBar, String ChangePassword, String OldPassword, String Password, String NewPassword,
            String NewPasswordText, String ConfirmNewPassword,  String ChnagePasswordButton)
        {
            _driver.FindElementByXPath(SideBar).Click();
            _driver.FindElementByXPath(ChangePassword).Click();

            _driver.FindElementById(OldPassword).SendKeys(Password);
            _driver.FindElementById(NewPassword).SendKeys(NewPasswordText);
            _driver.FindElementById(ConfirmNewPassword).SendKeys(NewPasswordText);
            _driver.FindElementById(ChnagePasswordButton).Click();
        }

        public void ReLogin(String LoginPasswordField, String Password, String LoginButton)
        {
            _driver.FindElementByXPath(LoginPasswordField).SendKeys(Password);
            _driver.FindElementById(LoginButton).Click();
        }

        public void SlideRegistration(String ZoneIcon, String LabelPresentOnPage)
        {
            new AuthUtils(_driver).WaitPageLoadById(ZoneIcon);
            IList<IWebElement> LabelPresent = _driver.FindElementsByXPath(LabelPresentOnPage);
            foreach (var Elements in LabelsAvailable)
            {
                foreach (var FocusElement in LabelPresent)
                {
                    if (Elements.Equals(FocusElement.Text))
                    {
                        new SendReusables(_driver).SwipeHorizontally();
                    }
                }  
            }
        }

        public void GoogleSignup(String GoogleSignup, String EmailAvailable, String Email, String AllowAccess)
        {
            _driver.FindElementByXPath(GoogleSignup).Click();
            IList<IWebElement> EmailElements = _driver.FindElementsByXPath(EmailAvailable);
            foreach (var Elements in EmailElements)
            {
                if (Email.Equals(Elements.Text))
                {
                    Elements.Click();
                }
            }
            _driver.FindElementByXPath(AllowAccess).Click();
        }

        public void ProfileImageCamera(String ProfileImage, String Camera)
        {
            _driver.FindElementByXPath(ProfileImage).Click();
            _driver.FindElementByXPath(Camera).Click();
            _driver.PressKeyCode(AndroidKeyCode.Keycode_CAMERA);

            Dimension = _driver.Manage().Window.Size;
            int StartPosition = Convert.ToInt32(Dimension.Width * 0.50);
            int EndPosition = Convert.ToInt32(Dimension.Height * 0.143);

            ITouchAction ITouchAction = new TouchAction(_driver);
            ITouchAction.Tap(StartPosition, EndPosition).Perform();
        }

        public void ProfileImageGallery(String ProfileImage,  String Gallery, String SelectImage)
        {
            _driver.FindElementByXPath(ProfileImage).Click();
            _driver.FindElementByXPath(Gallery).Click();
            IList<IWebElement> Element = _driver.FindElementsByXPath(SelectImage);
            Element[1].Click();
        }
    }
}
